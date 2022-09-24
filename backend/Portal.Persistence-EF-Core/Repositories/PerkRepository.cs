namespace Portal.Persistence_EF_Core.Repositories
{
    internal class PerkRepository : BaseRepository, IGenericRepository<PerkDomain>
    {
        public PerkRepository(IMapper mapper, PortalContext context) 
            : base(mapper, context) {}

        public async Task<PerkDomain> Create(PerkDomain entity)
        {
            return await Task.Run(() =>
            {
                var perkEntity = _mapper.Map<Perk>(entity);

                _context.Perks.Add(perkEntity);

                return entity;
            });
        }

        public async Task<int> Delete(PerkDomain entity)
        {
            return await Task.Run(() =>
            {
                var perkEntity = GetById(entity.Id);

                if (perkEntity == null)
                {
                    throw new DbEntityNotFoundException(nameof(Perk));
                }

                _context.Perks.Remove(perkEntity);

                return perkEntity.Id;
            });
        }

        public async Task<ICollection<PerkDomain>> Read()
        {
            return await Task.Run(() =>
            {
                var perks = _context.Perks.ToList();

                return perks.Select(x => _mapper.Map<PerkDomain>(x)).ToList();
            });
        }

        public async Task<ICollection<PerkDomain>> Read(ISpecification<PerkDomain> specification)
        {
            var res = await Read();

            return res.Where(specification).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<PerkDomain> Update(PerkDomain entity)
        {
            return await Task.Run(() =>
            {
                var perkEntity = GetById(entity.Id);

                if (perkEntity == null)
                {
                    throw new DbEntityNotFoundException(nameof(Perk));
                }

                perkEntity.MapFromPerkDomain(entity);

                _context.Perks.Update(perkEntity);

                return entity;
            });
        }
        
        private Perk GetById(int id)
        {
            return _context.Perks.First(u => u.Id == id); 
        }
    }
}
