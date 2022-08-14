using Portal.Application.Interfaces.OuterImpl;
using Portal.Domain.Entities;

namespace Portal.Persistence_EF_Core.Repositories
{
    internal class ArticleRepository : IGenericRepository<ArticleDomain>
    {
        public Task<ArticleDomain> Create(ArticleDomain entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(ArticleDomain entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ArticleDomain>> Read()
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<ArticleDomain> Update(ArticleDomain entity)
        {
            throw new NotImplementedException();
        }
    }
}
