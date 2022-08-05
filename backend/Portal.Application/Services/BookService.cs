using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Services
{
    internal class BookService : BaseModelService<Book>, IModelService<BookDTO>
    {
        public BookService(IGenericRepository<Book> repository, IMapper mapper)
            : base(repository, mapper) {}

        public async Task<BookDTO> Create(BookDTO entity)
        {
            var book = _mapper.Map<Book>(entity);

            book.CreatedAt = DateTime.Now;

            await _repository.Create(book);
            await _repository.SaveChanges();

            return _mapper.Map<BookDTO>(book);
        }

        public async Task<int> Delete(int id)
        {
            var books = await _repository.Read();
            var toDelete = books.FirstOrDefault(a => a.Id.Equals(id));

            if (toDelete is null)
            {
                throw new EntityNotFoundException(nameof(Book));
            }

            return await _repository.Delete(toDelete);
        }

        public async Task<ICollection<BookDTO>> GetAll()
        {
            var articles = await _repository.Read();

            return _mapper.Map<ICollection<BookDTO>>(articles);
        }

        public async Task<BookDTO> Update(BookDTO entity)
        {
            var articles = await _repository.Read();

            var toUpdate = articles.FirstOrDefault(a => a.Id.Equals(entity.Id));

            if (toUpdate is null)
            {
                throw new EntityNotFoundException(nameof(Book));
            }

            toUpdate.Title = entity.Title;
            toUpdate.Authors = entity.Authors;
            toUpdate.PageCount = entity.PageCount;
            toUpdate.Format = entity.Format;
            toUpdate.Published = entity.Published;

            toUpdate.UpdatedAt = DateTime.Now;

            await _repository.Update(toUpdate);

            return _mapper.Map<BookDTO>(toUpdate);
        }
    }
}
