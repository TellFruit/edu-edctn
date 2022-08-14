using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portal.Application.Interfaces.OuterImpl;
using Portal.Domain.Entities;
using Portal.Persistence_EF_Core.Repositories.Abstract;
using Portal.Persitence_EF_Core.FrameworkEntities;

namespace Portal.Persistence_EF_Core.Repositories
{
    internal class ArticleRepository : BaseRepository, IGenericRepository<ArticleDomain>
    {
        public ArticleRepository(IMapper mapper, PortalContext context)
            : base(mapper, context) {}

        public async Task<ArticleDomain> Create(ArticleDomain entity)
        {
            var articleEntity = _mapper.Map<Article>(entity);

            _context.Add(articleEntity);

            return entity;
        }

        public async Task<int> Delete(ArticleDomain entity)
        {
            var articleEntity = await _context.Materials.OfType<Article>()
                .FirstOrDefaultAsync(u => u.Id == entity.Id);

            //if (userEntity == null)
            //{
            //    throw new NotFoundException(nameof(User), userId);
            //}

            _context.Materials.Remove(articleEntity);
            return articleEntity.Id;
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
