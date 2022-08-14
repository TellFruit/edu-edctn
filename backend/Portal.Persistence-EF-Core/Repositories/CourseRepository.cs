using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portal.Application.Interfaces.OuterImpl;
using Portal.Domain.Entities;
using Portal.Persistence_EF_Core.Repositories.Abstract;
using Portal.Persitence_EF_Core.FrameworkEntities;
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

            _context.Add(courseEntity);

            return entity;
        }

        public async Task<int> Delete(CourseDomain entity)
        {
            var courseEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == entity.Id);

            //if (userEntity == null)
            //{
            //    throw new NotFoundException(nameof(User), userId);
            //}

            _context.Users.Remove(courseEntity);
            return courseEntity.Id;
        }

        public async Task<ICollection<CourseDomain>> Read()
        {
            var courses = await _context.Materials.OfType<Course>()
                .ToListAsync();

            return _mapper.Map<List<CourseDomain>>(courses);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<CourseDomain> Update(CourseDomain entity)
        {
            var courseEntity = await _context.Materials.OfType<Course>()
                .FirstOrDefaultAsync(u => u.Id == entity.Id);

            var data = _mapper.Map<Course>(entity);

            courseEntity.Name = data.Name;
            courseEntity.Description = data.Description;
            courseEntity.User = data.User;
            courseEntity.Materials = data.Materials;
            courseEntity.UpdatedAt = data.UpdatedAt;

            _context.Update(courseEntity);

            return entity;
        }
    }
}
