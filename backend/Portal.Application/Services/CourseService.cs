namespace Portal.Application.Services
{
    internal class CourseService : BaseModelService<CourseDomain>, ICourseService
    {
        public CourseService(IGenericRepository<CourseDomain> repository, IMapper mapper)
            : base(repository, mapper) {}

        public async Task<CourseDTO> Create(CourseDTO entity)
        {
            if (entity.Validate(new CourseValidator()))
            {
                return new CourseDTO();
            }

            var course = _mapper.Map<CourseDomain>(entity);

            course.CreatedAt = DateTime.Now;
            course.UpdatedAt = DateTime.Now;

            await _repository.Create(course);
            _repository.SaveChanges();

            return _mapper.Map<CourseDTO>(course);
        }

        public async Task<int> Delete(int id)
        {
            var courses = await _repository.Read();
            var toDelete = courses.FirstOrDefault(a => a.Id.Equals(id));

            if (toDelete is null)
            {
                throw new EntityNotFoundException(nameof(CourseDomain));
            }

            int result = await _repository.Delete(toDelete);
            _repository.SaveChanges();

            return result;
        }

        public async Task<ICollection<CourseDTO>> GetAll()
        {
            var courses = await _repository.Read();

            return _mapper.Map<ICollection<CourseDTO>>(courses);
        }

        public async Task<CourseDTO> GetById(int id)
        {
            var courses = await _repository.Read();

            var wantedCourse = courses.FirstOrDefault(c => c.Id.Equals(id));

            return _mapper.Map<CourseDTO>(wantedCourse);
        }

        public async Task<ICollection<CourseDTO>> GetBySpec(ISpecification<CourseDomain> specification)
        {
            var courses = await _repository.Read(specification);

            return _mapper.Map<ICollection<CourseDTO>>(courses);
        }

        public async Task<CourseDTO> Update(CourseDTO entity)
        {
            if (entity.Validate(new CourseValidator()))
            {
                return new CourseDTO();
            }

            var courses = await _repository.Read();

            var toUpdate = courses.FirstOrDefault(a => a.Id.Equals(entity.Id));
            var data = _mapper.Map<CourseDomain>(entity);
            
            if (toUpdate is null)
            {
                throw new EntityNotFoundException(nameof(CourseDomain));
            }

            toUpdate.Name = data.Name;
            toUpdate.Description = data.Description;
            toUpdate.Materials = data.Materials;
            toUpdate.Perks = data.Perks;

            toUpdate.UpdatedAt = DateTime.Now;

            await _repository.Update(toUpdate);
            _repository.SaveChanges();

            return _mapper.Map<CourseDTO>(toUpdate);
        }
    }
}
