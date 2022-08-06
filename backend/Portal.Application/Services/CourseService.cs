namespace Portal.Application.Services
{
    internal class CourseService : BaseModelService<Course>, ICourseService
    {
        public CourseService(IGenericRepository<Course> repository, IMapper mapper)
            : base(repository, mapper) {}

        public async Task<CourseDTO> Create(CourseDTO entity)
        {
            var course = _mapper.Map<Course>(entity);

            course.CreatedAt = DateTime.Now;

            await _repository.Create(course);
            await _repository.SaveChanges();

            return _mapper.Map<CourseDTO>(course);
        }

        public async Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CourseDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<CourseDTO> Update(CourseDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
