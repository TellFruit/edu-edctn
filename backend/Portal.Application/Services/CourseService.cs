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
            var courses = await _repository.Read();
            var toDelete = courses.FirstOrDefault(a => a.Id.Equals(id));

            if (toDelete is null)
            {
                throw new EntityNotFoundException(nameof(Course));
            }

            return await _repository.Delete(toDelete);
        }

        public async Task<ICollection<CourseDTO>> GetAll()
        {
            var courses = await _repository.Read();

            return _mapper.Map<ICollection<CourseDTO>>(courses);
        }

        public async Task<CourseDTO> Update(CourseDTO entity)
        {
            var courses = await _repository.Read();

            var toUpdate = courses.FirstOrDefault(a => a.Id.Equals(entity.Id));
            var data = _mapper.Map<Course>(entity);
            
            if (toUpdate is null)
            {
                throw new EntityNotFoundException(nameof(Course));
            }

            toUpdate.Name = data.Name;
            toUpdate.Description = data.Description;
            toUpdate.Author = data.Author;
            toUpdate.Materials = data.Materials;

            toUpdate.UpdatedAt = DateTime.Now;

            await _repository.Update(toUpdate);

            return _mapper.Map<CourseDTO>(toUpdate);
        }
    }
}
