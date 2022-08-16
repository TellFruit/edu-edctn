using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portal.Application.Interfaces.OuterImpl;
using Portal.Domain.Entities;
using Portal.Persistence_EF_Core.FrameworkEntities;
using Portal.Persistence_EF_Core.Repositories.Abstract;
using Portal.Persitence_EF_Core.FrameworkEntities;
using Portal.Persitence_EF_Core.FrameworkEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence_EF_Core.Repositories
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

            courseEntity.Materials = null;

            courseEntity.CourseMaterials = courseMaterials;

            _context.Courses.Add(courseEntity);

            return entity;
        }

        public async Task<int> Delete(CourseDomain entity)
        {
            var courseEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == entity.Id);

            _context.Users.Remove(courseEntity);
            return courseEntity.Id;
        }

        public async Task<ICollection<CourseDomain>> Read()
        {
            var courses = _context.Courses.Include(c => c.Materials).ToList();

            return courses.Select(x => _mapper.Map<CourseDomain>(x)).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<CourseDomain> Update(CourseDomain entity)
        {
            var courseEntity = await _context.Courses.Include(c => c.CourseMaterials)
                .FirstOrDefaultAsync(u => u.Id == entity.Id);

            var data = _mapper.Map<Course>(entity);

            var updatedCourseMaterials = data.Materials
                .Select(m => new CourseMaterial
                {
                    CourseId = data.Id,
                    MaterialId = m.Id
                })
                .ToList();

            courseEntity.Name = data.Name;
            courseEntity.Description = data.Description;
            //courseEntity.User = data.User;
            courseEntity.UpdatedAt = data.UpdatedAt;
            courseEntity.CourseMaterials = updatedCourseMaterials;

            _context.Update(courseEntity);

            return entity;
        }
    }
}
