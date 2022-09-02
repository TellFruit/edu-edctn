﻿namespace Portal.Persistence_EF_Core.Repositories
{
    internal class CourseRepository : BaseRepository, IGenericRepository<CourseDomain>
    {
        public CourseRepository(IMapper mapper, PortalContext context)
            : base(mapper, context) {}

        public async Task<CourseDomain> Create(CourseDomain entity)
        {
            var courseEntity = _mapper.Map<Course>(entity);

            var courseMaterials = new List<CourseMaterial>();

            foreach (var material in entity.Materials)
            {
                courseMaterials.Add(new CourseMaterial
                {
                    MaterialId = material.Id
                });
            }

            var coursePerks = new List<CoursePerk>();

            foreach (var perk in entity.Perks)
            {
                coursePerks.Add(new CoursePerk
                {
                    PerkId = perk.Id
                });
            }

            courseEntity.CourseMaterials = courseMaterials;
            courseEntity.CoursePerks = coursePerks;

            _context.Courses.Add(courseEntity);

            return entity;
        }

        public async Task<int> Delete(CourseDomain entity)
        {
            var courseEntity = GetBydId(entity.Id);

            if (courseEntity == null)
            {
                throw new DbEntityNotFoundException(nameof(Course));
            }

            _context.Courses.Remove(courseEntity);
            return courseEntity.Id;
        }

        public async Task<ICollection<CourseDomain>> Read()
        {
            var courses = _context.Courses
                .Include(c => c.CourseMaterials)
                    .ThenInclude(cm => cm.Material)
                .Include(c => c.CoursePerks)
                    .ThenInclude(cp => cp.Perk)
                .ToList();

            return courses.Select(x => _mapper.Map<CourseDomain>(x)).ToList();
        }

        public async Task<ICollection<CourseDomain>> Read(Func<CourseDomain, bool> predicate)
        {
            var res = await Read();

            return res.Where(predicate).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<CourseDomain> Update(CourseDomain entity)
        {
            var courseEntity = GetBydId(entity.Id);

            if (courseEntity == null)
            {
                throw new DbEntityNotFoundException(nameof(Course));
            }

            var updatedCourseMaterials = entity.Materials
                .Select(m => new CourseMaterial
                {
                    CourseId = entity.Id,
                    MaterialId = m.Id
                }) 
                .ToList();

            var updatedCoursePerks = entity.Perks
                .Select(p => new CoursePerk
                {
                    CourseId = entity.Id,
                    PerkId = p.Id
                })
                .ToList();

            courseEntity.Name = entity.Name;
            courseEntity.Description = entity.Description;
            courseEntity.UpdatedAt = entity.UpdatedAt;
            courseEntity.CourseMaterials = updatedCourseMaterials;
            courseEntity.CoursePerks = updatedCoursePerks;

            _context.Update(courseEntity);

            return entity;
        }

        private Course GetBydId(int id)
        {
            return _context.Courses.First(u => u.Id == id);
        }
    }
}
