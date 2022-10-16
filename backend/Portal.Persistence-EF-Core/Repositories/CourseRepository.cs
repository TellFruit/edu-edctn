namespace Portal.Persistence_EF_Core.Repositories
{
    internal class CourseRepository : BaseRepository, IGenericRepository<CourseDomain>
    {
        public CourseRepository(IMapper mapper, PortalContext context)
            : base(mapper, context) {}

        public async Task<CourseDomain> Create(CourseDomain entity)
        {
            return await Task.Run(() =>
            {
                var courseEntity = _mapper.Map<Course>(entity);

                var courseMaterials = entity.Materials.ToCourseMaterials();

                var coursePerks = entity.Perks.ToCoursePerks();

                courseEntity.CourseMaterials = courseMaterials;
                courseEntity.CoursePerks = coursePerks;

                _context.Courses.Add(courseEntity);

                return entity;
            });
        }

        public async Task<int> Delete(CourseDomain entity)
        {
            return await Task.Run(() =>
            {
                var courseEntity = GetBydId(entity.Id);

                if (courseEntity == null)
                {
                    throw new DbEntityNotFoundException(nameof(Course));
                }

                _context.Courses.Remove(courseEntity);

                return courseEntity.Id;
            });
        }

        public async Task<ICollection<CourseDomain>> Read()
        {
            return await Task.Run(() =>
            {
                var courses = _context.Courses
                .Include(c => c.CourseMaterials)
                    .ThenInclude(cm => cm.Material)
                .Include(c => c.CoursePerks)
                    .ThenInclude(cp => cp.Perk)
                .ToList();

                return courses.Select(x => _mapper.Map<CourseDomain>(x)).ToList();
            });
        }

        public async Task<ICollection<CourseDomain>> Read(ISpecification<CourseDomain> specification)
        {
            var res = await Read();

            return res.Where(specification).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<CourseDomain> Update(CourseDomain entity)
        {
            return await Task.Run(() =>
            {
                var courseEntity = GetBydId(entity.Id);

                if (courseEntity == null)
                {
                    throw new DbEntityNotFoundException(nameof(Course));
                }

                var updatedCourseMaterials = entity.Materials
                    .ToCourseMaterials(entity.Id);

                var updatedCoursePerks = entity.Perks
                    .ToCoursePerks(entity.Id);

                courseEntity.MapFromCourseDomain(entity,
                    updatedCourseMaterials,
                    updatedCoursePerks);

                _context.Update(courseEntity);

                return entity;
            });
        }

        private Course GetBydId(int id)
        {
            return _context.Courses.First(u => u.Id == id);
        }
    }
}
