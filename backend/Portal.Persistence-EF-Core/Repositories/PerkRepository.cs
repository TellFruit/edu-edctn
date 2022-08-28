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

        public async Task<ICollection<PerkDomain>> Read(Func<PerkDomain, bool> predicate)
        {
            var res = await Read();

            return res.Where(predicate).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<PerkDomain> Update(PerkDomain entity)
        {
            var perkEntity = _context.Perks
                .FirstOrDefault(u => u.Id == entity.Id);

            var data = _mapper.Map<Perk>(entity);

            if (perkEntity == null)
            {
                throw new DbEntityNotFoundException(nameof(Perk));
            }

            perkEntity.Name = data.Name;
            perkEntity.UpdatedAt = data.UpdatedAt;

            _context.Perks.Update(perkEntity);

            return entity;
        }
    }
}
