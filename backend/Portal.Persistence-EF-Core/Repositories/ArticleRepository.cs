namespace Portal.Persistence_EF_Core.Repositories
{
    internal class ArticleRepository : BaseRepository, IGenericRepository<ArticleDomain>
    {
        public ArticleRepository(IMapper mapper, PortalContext context)
            : base(mapper, context) { }

        public async Task<ArticleDomain> Create(ArticleDomain entity)
        {
            return await Task.Run(() =>
            {
                var articleEntity = _mapper.Map<Article>(entity);

                _context.Add(articleEntity);

                return entity;
            });
        }

        public async Task<int> Delete(ArticleDomain entity)
        {
            return await Task.Run(() =>
            {
                var articleEntity = GetById(entity.Id);

                if (articleEntity == null)
                {
                    throw new DbEntityNotFoundException(nameof(Article));
                }

                _context.Materials.Remove(articleEntity);

                return articleEntity.Id;
            });
        }

        public async Task<ICollection<ArticleDomain>> Read()
        {
            return await Task.Run(() =>
            {
                var articles = _context.Materials.OfType<Article>().ToList();

                return articles.Select(x => _mapper.Map<ArticleDomain>(x)).ToList();
            });
        }

        public async Task<ICollection<ArticleDomain>> Read(ISpecification<ArticleDomain> specification)
        {
            var res = await Read();

            return res.Where(specification).ToList();
        }

        public void SaveChanges()
        { 
            _context.SaveChanges();
        }

        public async Task<ArticleDomain> Update(ArticleDomain entity)
        {
            return await Task.Run(() =>
            {
                var articleEntity = GetById(entity.Id);

                if (articleEntity == null)
                {
                    throw new DbEntityNotFoundException(nameof(Article));
                }

                articleEntity.MapFromArticleDomain(entity);

                _context.Materials.Update(articleEntity);

                return entity;
            });
        }

        private Article GetById(int id)
        {
            return _context.Materials.OfType<Article>()
                .First(u => u.Id == id);
        }
    }
}
