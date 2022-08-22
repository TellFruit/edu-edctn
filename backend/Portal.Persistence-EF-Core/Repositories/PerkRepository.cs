namespace Portal.Persistence_EF_Core.Repositories
{
    internal class PerkRepository : BaseRepository, IGenericRepository<PerkDomain>
    {
        public PerkRepository(IMapper mapper, PortalContext context) 
            : base(mapper, context) {}

        public async Task<PerkDomain> Create(PerkDomain entity)
        {
            var perkEntity = _mapper.Map<Perk>(entity);

            _context.Perks.Add(perkEntity);

            return entity;
        }

        public async Task<int> Delete(PerkDomain entity)
        {
            var perkEntity = _context.Perks
                .FirstOrDefault(u => u.Id == entity.Id);

            if (perkEntity == null)
            {
                throw new DbEntityNotFoundException(nameof(Perk));
            }

            _context.Perks.Remove(perkEntity);
            return perkEntity.Id;
        }

        public async Task<ICollection<PerkDomain>> Read()
        {
            var perks = _context.Perks.ToList();

            return perks.Select(x => _mapper.Map<PerkDomain>(x)).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task<PerkDomain> Update(PerkDomain entity)
        {
            throw new NotImplementedException();
        }
    }
}
