using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Services
{
    internal class ArticleService : IModelService<ArticleDTO>
    {
        private readonly IGenericRepository<Article> _repository;

        public ArticleService(IGenericRepository<Article> repository)
        {
            _repository = repository;
        }

        public Task<ArticleDTO> Create(ArticleDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(ArticleDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ArticleDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ArticleDTO> Update(ArticleDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
