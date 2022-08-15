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

        public async Task<ICollection<ArticleDomain>> Read()
        {
            var articles = _context.Materials.OfType<Article>()
                .ToList();

            return articles.Select(x => _mapper.Map<ArticleDomain>(x)).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<ArticleDomain> Update(ArticleDomain entity)
        {
            var articleEntity = await _context.Materials.OfType<Article>()
                .FirstOrDefaultAsync(u => u.Id == entity.Id);

            var data = _mapper.Map<Article>(entity);

            articleEntity.Title = data.Title;
            articleEntity.Url = data.Url;
            articleEntity.Perks = data.Perks;
            articleEntity.Published = data.Published;
            articleEntity.UpdatedAt = data.UpdatedAt;

            _context.Materials.Update(articleEntity);

            return entity;
        }
    }
}
