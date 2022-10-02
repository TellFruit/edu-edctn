namespace Portal.Application.Services
{
    internal class ArticleService : BaseModelService<ArticleDomain>, IArticleService
    {
        private readonly AbstractValidator<ArticleDTO> _validator;

        public ArticleService(IGenericRepository<ArticleDomain> repository, IMapper mapper, AbstractValidator<ArticleDTO> validator)
            : base(repository, mapper)
        {
            _validator = validator;
        }

        public async Task<ArticleDTO> Create(ArticleDTO entity)
        {
            if (entity.Validate(_validator) is false)
            {
                return new ArticleDTO();
            }

            var article = _mapper.Map<ArticleDomain>(entity);

            article.CreatedAt = DateTime.Now;
            article.UpdatedAt = DateTime.Now;

            await _repository.Create(article);
            _repository.SaveChanges();

            return _mapper.Map<ArticleDTO>(article);
        }

        public async Task<int> Delete(int id)
        {
            var articles = await _repository.Read();
            var toDelete = articles.FirstOrDefault(a => a.Id.Equals(id));

            if (toDelete is null)
            {
                throw new EntityNotFoundException(nameof(ArticleDomain));
            }

            int resultId = await _repository.Delete(toDelete);
            _repository.SaveChanges();
            return resultId;
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

        public async Task<ICollection<ArticleDTO>> GetBySpec(ISpecification<ArticleDomain> specification)
        {
            var articles = await _repository.Read(specification);

            return _mapper.Map<ICollection<ArticleDTO>>(articles);
        }

        public async Task<ArticleDTO> Update(ArticleDTO entity)
        {
            if (entity.Validate(_validator) is false)
            {
                return new ArticleDTO();
            }

            var articles = await _repository.Read();

            var toUpdate = articles.FirstOrDefault(a => a.Id.Equals(entity.Id));
            var data = _mapper.Map<ArticleDomain>(entity);

            if (toUpdate is null)
            {
                throw new EntityNotFoundException(nameof(ArticleDomain));
            }

            toUpdate.Title = data.Title;
            toUpdate.Url = data.Url;
            toUpdate.Published = data.Published;

            toUpdate.UpdatedAt = DateTime.Now;

            await _repository.Update(toUpdate);
            _repository.SaveChanges();

            return _mapper.Map<ArticleDTO>(toUpdate);
        }
    }
}
