using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Services
{
    internal class ArticleService : IModelService<ArticleDTO>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Article> _repository;

        public ArticleService(IGenericRepository<Article> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ArticleDTO> Create(ArticleDTO entity)
        {
            var article = _mapper.Map<Article>(entity);

            await _repository.Create(article);
            await _repository.SaveChanges();

            return _mapper.Map<ArticleDTO>(article);
        }

        public async Task<int> Delete(int id)
        {
            var articles = await _repository.Read();

            return await _repository.Delete(articles.FirstOrDefault(x => x.Id == id));
        }

        public async Task<ICollection<ArticleDTO>> GetAll()
        {
            var articles = await _repository.Read();

            return _mapper.Map<ICollection<ArticleDTO>>(articles);
        }

        public Task<ArticleDTO> Update(ArticleDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
