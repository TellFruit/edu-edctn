using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Services
{
    internal class ArticleService : IModelService<Article>
    {
        public Task<Article> Create(Article entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Article entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Article>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Article> Update(Article entity)
        {
            throw new NotImplementedException();
        }
    }
}
