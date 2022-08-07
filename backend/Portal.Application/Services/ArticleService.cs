namespace Portal.Application.Services
{
    internal class ArticleService : BaseModelService<Article>, IArticleService
    {
        public ArticleService(IGenericRepository<Article> repository, IMapper mapper) 
            : base(repository, mapper) {}

        public async Task<ArticleDTO> Create(ArticleDTO entity)
        {
            var article = _mapper.Map<Article>(entity);

            article.CreatedAt = DateTime.Now;

            await _repository.Create(article);
            await _repository.SaveChanges();

            return _mapper.Map<ArticleDTO>(article);
        }

        public async Task<int> Delete(int id)
        {
            var articles = await _repository.Read();
            var toDelete = articles.FirstOrDefault(a => a.Id.Equals(id));

            if (toDelete is null)
            {
                throw new EntityNotFoundException(nameof(Article));
            }

            return await _repository.Delete(toDelete);
        }

        public async Task<ICollection<ArticleDTO>> GetAll()
        {
            var articles = await _repository.Read();

            return _mapper.Map<ICollection<ArticleDTO>>(articles);
        }

        public async Task<ArticleDTO> GetById(int id)
        {
            var articles = await _repository.Read();

            var wantedArticle = articles.FirstOrDefault(a => a.Id.Equals(id));

            return _mapper.Map<ArticleDTO>(wantedArticle);
        }

        public async Task<ArticleDTO> Update(ArticleDTO entity)
        {
            var articles = await _repository.Read();

            var toUpdate = articles.FirstOrDefault(a => a.Id.Equals(entity.Id));
            var data = _mapper.Map<Article>(entity);

            if (toUpdate is null)
            {
                throw new EntityNotFoundException(nameof(Article));
            }

            toUpdate.Title = data.Title;
            toUpdate.Url = data.Url;
            toUpdate.Perks = data.Perks;

            toUpdate.UpdatedAt = DateTime.Now;

            await _repository.Update(toUpdate);

            return _mapper.Map<ArticleDTO>(toUpdate);
        }
    }
}
