namespace Portal.Application.Services
{
    internal class BookService : BaseModelService<BookDomain>, IBookService
    {
        public BookService(IGenericRepository<BookDomain> repository, IMapper mapper)
            : base(repository, mapper) {}

        public async Task<BookDTO> Create(BookDTO entity)
        {
            if (entity.Validate(new BookValidator()))
            {
                return new BookDTO();
            }

            var book = _mapper.Map<BookDomain>(entity);

            book.CreatedAt = DateTime.Now;
            book.UpdatedAt = DateTime.Now;

            await _repository.Create(book);
            _repository.SaveChanges();

            return _mapper.Map<BookDTO>(book);
        }

        public async Task<int> Delete(int id)
        {
            var books = await _repository.Read();
            var toDelete = books.FirstOrDefault(a => a.Id.Equals(id));

            if (toDelete is null)
            {
                throw new EntityNotFoundException(nameof(BookDomain));
            }
            
            int result = await _repository.Delete(toDelete);
            _repository.SaveChanges();

            return result;
        }

        public async Task<ICollection<BookDTO>> GetAll()
        {
            var books = await _repository.Read();

            return _mapper.Map<ICollection<BookDTO>>(books);
        }

        public async Task<BookDTO> GetById(int id)
        {
            var books = await _repository.Read();

            var wantedBook = books.FirstOrDefault(b => b.Id.Equals(id));

            return _mapper.Map<BookDTO>(wantedBook);
        }

        public async Task<ICollection<BookDTO>> GetBySpec(ISpecification<BookDomain> specification)
        {
            var books = await _repository.Read(specification);

            return _mapper.Map<ICollection<BookDTO>>(books);
        }

        public async Task<BookDTO> Update(BookDTO entity)
        {
            if (entity.Validate(new BookValidator()) is false)
            {
                return new BookDTO();
            }

            var articles = await _repository.Read();

            var toUpdate = articles.FirstOrDefault(a => a.Id.Equals(entity.Id)); 
            var data = _mapper.Map<BookDomain>(entity);

            if (toUpdate is null)
            {
                throw new EntityNotFoundException(nameof(BookDomain));
            }

            toUpdate.Title = data.Title;
            toUpdate.Authors = data.Authors;
            toUpdate.PageCount = data.PageCount;
            toUpdate.Format = data.Format;
            toUpdate.Published = data.Published;

            toUpdate.UpdatedAt = DateTime.Now;

            await _repository.Update(toUpdate);
            _repository.SaveChanges();

            return _mapper.Map<BookDTO>(toUpdate);
        }
    }
}
