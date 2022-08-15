using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portal.Application.Interfaces.OuterImpl;
using Portal.Domain.Entities;
using Portal.Persistence_EF_Core.Repositories.Abstract;
using Portal.Persitence_EF_Core.FrameworkEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence_EF_Core.Repositories
{
    internal class BookRepository : BaseRepository, IGenericRepository<BookDomain>
    {
        public BookRepository(IMapper mapper, PortalContext context)
            : base(mapper, context) {}

        public async Task<BookDomain> Create(BookDomain entity)
        {
            var bookEntity = _mapper.Map<Book>(entity);

            _context.Add(bookEntity);

            return entity;
        }

        public async Task<int> Delete(BookDomain entity)
        {
            var bookEntity = await _context.Materials.OfType<Book>()
                .FirstOrDefaultAsync(u => u.Id == entity.Id);

            //if (userEntity == null)
            //{
            //    throw new NotFoundException(nameof(User), userId);
            //}

            _context.Materials.Remove(bookEntity);
            return bookEntity.Id;
        }

        public async Task<ICollection<BookDomain>> Read()
        {
            var books = await _context.Materials.OfType<Book>()
                .ToListAsync();

            return books.Select(x => _mapper.Map<BookDomain>(x)).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<BookDomain> Update(BookDomain entity)
        {
            var bookEntity = await _context.Materials.OfType<Book>()
                .FirstOrDefaultAsync(u => u.Id == entity.Id);

            var data = _mapper.Map<Book>(entity);

            bookEntity.Title = data.Title;
            bookEntity.Authors = data.Authors;
            bookEntity.PageCount = data.PageCount;
            bookEntity.Format = data.Format;
            bookEntity.Published = data.Published;
            bookEntity.Perks = data.Perks;
            bookEntity.UpdatedAt = data.UpdatedAt;

            _context.Materials.Update(bookEntity);

            return entity;
        }
    }
}
