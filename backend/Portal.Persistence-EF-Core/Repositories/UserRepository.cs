namespace Portal.Persistence_EF_Core.Repositories
{
    internal class UserRepository : BaseRepository, IGenericRepository<UserDomain>
    {
        public UserRepository(IMapper mapper, PortalContext context)
            : base(mapper, context) {}

        public async Task<UserDomain> Create(UserDomain entity)
        {
            var userEntity = _mapper.Map<User>(entity);

            _context.Users.Add(userEntity);

            return entity;
        }

        public async Task<int> Delete(UserDomain entity)
        {
            var userEntity = _context.Users.FirstOrDefault(u => u.Id == entity.Id);

            if (userEntity == null)
            {
                throw new DbEntityNotFoundException(nameof(User));
            }

            _context.Users.Remove(userEntity);
            return userEntity.Id;
        }

        public async Task<ICollection<UserDomain>> Read()
        {
            var users = _context.Users
                .Include(u => u.UserCourses)
                .Include(u => u.UserMaterial)
                .Include(u => u.UserPerks)
                .ToList();

            return users.Select(x => _mapper.Map<UserDomain>(x)).ToList();
        }

        public async Task<ICollection<UserDomain>> Read(Func<UserDomain, bool> predicate)
        {
            var res = await Read();

            return res.Where(predicate).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<UserDomain> Update(UserDomain entity)
        {
            var userEntity = _context.Users
                .Include(u => u.UserCourses)
                .FirstOrDefault(u => u.Id == entity.Id);

            var data = _mapper.Map<User>(entity);

            if (userEntity == null)
            {
                throw new DbEntityNotFoundException(nameof(User));
            }

            var updatedUserCourses = entity.CourseProgress
                .Select(c => new UserCourse
                {
                    UserId = c.UserId,
                    CourseId = c.CourseId,
                    Progress = c.Progress
                })
                .ToList();

            var updatedUserMaterial = entity.MaterialLearned
                .Select(m => new UserMaterial
                {
                    UserId = m.UserId,
                    MaterialId = m.MaterialId,
                })
                .ToList();

            userEntity.FirstName = data.FirstName;
            userEntity.LastName = data.LastName;
            userEntity.Email = data.Email;
            userEntity.Password = data.Password;
            userEntity.Roles = data.Roles;
            userEntity.UpdatedAt = data.UpdatedAt;
            userEntity.UserCourses = updatedUserCourses;
            userEntity.UserMaterial = updatedUserMaterial;

            _context.Update(userEntity);

            return entity;
        }
    }
}
