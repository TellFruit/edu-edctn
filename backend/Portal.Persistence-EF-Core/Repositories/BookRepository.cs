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
            var bookEntity = GetById(entity.Id);

            if (bookEntity == null)
            {
                throw new DbEntityNotFoundException(nameof(Book));
            }

            _context.Materials.Remove(bookEntity);

            return bookEntity.Id;
        }

        public async Task<ICollection<BookDomain>> Read()
        {
            var books = _context.Materials.OfType<Book>().ToList();

            return books.Select(x => _mapper.Map<BookDomain>(x)).ToList();
        }

        public async Task<ICollection<BookDomain>> Read(ISpecification<BookDomain> specification)
        {
            var res = await Read();

            return res.Where(specification).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<BookDomain> Update(BookDomain entity)
        {
            var bookEntity = GetById(entity.Id);

            if (bookEntity == null)
            {
                throw new DbEntityNotFoundException(nameof(Book));
            }

            bookEntity.MapFormBookDomain(entity);

            _context.Materials.Update(bookEntity);

            return entity;
        }

        private Book GetById(int id)
        {
            return _context.Materials.OfType<Book>()
                .First(u => u.Id == id);
        }
    }
}
