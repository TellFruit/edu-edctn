namespace Portal.Application.Services
{
    internal class PerkService : BaseModelService<PerkDomain>, IPerkService
    {
        public PerkService(IGenericRepository<PerkDomain> repository, IMapper mapper)
            : base(repository, mapper) {}

        public async Task<PerkDTO> Create(PerkDTO entity)
        {
            var perk = _mapper.Map<PerkDomain>(entity);

            perk.CreatedAt = DateTime.Now;
            perk.UpdatedAt = DateTime.Now;

            await _repository.Create(perk);
            await _repository.SaveChanges();

            return _mapper.Map<PerkDTO>(perk);
        }

        public async Task<int> Delete(int id)
        {
            var perks = await _repository.Read();
            var toDelete = perks.FirstOrDefault(a => a.Id.Equals(id));

            if (toDelete is null)
            {
                throw new EntityNotFoundException(nameof(PerkDomain));
            }

            int result = await _repository.Delete(toDelete);
            await _repository.SaveChanges();

            return result;
        }

        public async Task<ICollection<PerkDTO>> GetAll()
        {
            var perks = await _repository.Read();

            return _mapper.Map<ICollection<PerkDTO>>(perks);
        }

        public async Task<PerkDTO> GetById(int id)
        {
            var perks = await _repository.Read();

            var wantedPerk = perks.FirstOrDefault(c => c.Id.Equals(id));

            return _mapper.Map<PerkDTO>(wantedPerk);
        }

        public async Task<PerkDTO> Update(PerkDTO entity)
        {
            var perks = await _repository.Read();

            var toUpdate = perks.FirstOrDefault(a => a.Id.Equals(entity.Id));
            var data = _mapper.Map<PerkDomain>(entity);

            if (toUpdate is null)
            {
                throw new EntityNotFoundException(nameof(PerkDomain));
            }

            toUpdate.Name = data.Name;

            toUpdate.UpdatedAt = DateTime.Now;

            await _repository.Update(toUpdate);
            await _repository.SaveChanges();

            return _mapper.Map<PerkDTO>(toUpdate);
        }
    }
}
