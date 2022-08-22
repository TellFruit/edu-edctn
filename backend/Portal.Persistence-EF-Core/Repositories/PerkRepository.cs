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

        public Task<int> Delete(PerkDomain entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PerkDomain>> Read()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<PerkDomain> Update(PerkDomain entity)
        {
            throw new NotImplementedException();
        }
    }
}
