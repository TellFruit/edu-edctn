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

            await _repository.Create(book);
            await _repository.SaveChanges();

            return _mapper.Map<BookDTO>(book);
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<BookDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BookDTO> Update(BookDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
