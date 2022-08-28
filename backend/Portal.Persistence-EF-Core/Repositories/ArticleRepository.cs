namespace Portal.Persistence_EF_Core.Repositories
{
    internal class ArticleRepository : BaseRepository, IGenericRepository<ArticleDomain>
    {
        public ArticleRepository(IMapper mapper, PortalContext context)
            : base(mapper, context) { }

        public async Task<ArticleDomain> Create(ArticleDomain entity)
        {
            var articleEntity = _mapper.Map<Article>(entity);

            _context.Add(articleEntity);

            return entity;
        }

        public async Task<int> Delete(ArticleDomain entity)
        {
            var articleEntity = _context.Materials.OfType<Article>()
                .FirstOrDefault(u => u.Id == entity.Id);

            if (articleEntity == null)
            {
                throw new DbEntityNotFoundException(nameof(Article));
            }

            _context.Materials.Remove(articleEntity);
            return articleEntity.Id;
        }

        public async Task<ICollection<ArticleDomain>> Read()
        {
            var articles = _context.Materials.OfType<Article>().ToList();

            return articles.Select(x => _mapper.Map<ArticleDomain>(x)).ToList();
        }

        public async Task<ICollection<ArticleDomain>> Read(Func<ArticleDomain, bool> predicate)
        {
            var articles = _context.Materials.OfType<Article>().ToList();

            return articles
                .Select(x => _mapper.Map<ArticleDomain>(x))
                .Where(predicate)
                .ToList();
        }

        public void SaveChanges()
        { 
            _context.SaveChanges();
        }

        public async Task<ArticleDomain> Update(ArticleDomain entity)
        {
            var articleEntity = _context.Materials.OfType<Article>()
                .FirstOrDefault(u => u.Id == entity.Id);

            var data = _mapper.Map<Article>(entity);

            if (articleEntity == null)
            {
                throw new DbEntityNotFoundException(nameof(Article));
            }

            articleEntity.Title = data.Title;
            articleEntity.Url = data.Url;
            articleEntity.Published = data.Published;
            articleEntity.UpdatedAt = data.UpdatedAt;

            _context.Materials.Update(articleEntity);

            return entity;
        }
    }
}
