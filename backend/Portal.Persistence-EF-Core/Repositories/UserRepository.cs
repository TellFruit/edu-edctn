namespace Portal.Persistence_EF_Core.Repositories
{
    internal class UserRepository : BaseRepository, IGenericRepository<UserDomain>
    {
        public UserRepository(IMapper mapper, PortalContext context)
            : base(mapper, context) {}

        public async Task<UserDomain> Create(UserDomain entity)
        {
            return await Task.Run(() =>
            {
                var userEntity = _mapper.Map<User>(entity);

                _context.Users.Add(userEntity);

                return entity;
            });
        }

        public async Task<int> Delete(UserDomain entity)
        {
            return await Task.Run(() =>
            {
                var userEntity = GetById(entity.Id);

                if (userEntity == null)
                {
                    throw new DbEntityNotFoundException(nameof(User));
                }

                _context.Users.Remove(userEntity);

                return userEntity.Id;
            });
        }

        public async Task<ICollection<UserDomain>> Read()
        {
            var users = _context.Users
                .Include(u => u.UserCourses)
                    .ThenInclude(uc => uc.Course)
                        .ThenInclude(c => c.CourseMaterials)
                            .ThenInclude(cm => cm.Material)
                .Include(u => u.UserMaterial)
                    .ThenInclude(um => um.Material)
                .Include(u => u.UserPerks)
                    .ThenInclude(up => up.Perk)
                .ToList();

            return users.Select(x => _mapper.Map<UserDomain>(x)).ToList();

            //return await Task.Run(() =>
            //{
                
            //});
        }

        public async Task<ICollection<UserDomain>> Read(ISpecification<UserDomain> specification)
        {
            var res = await Read();

            return res.Where(specification).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<UserDomain> Update(UserDomain entity)
        {
            return await Task.Run(() =>
            {
                var userEntity = GetById(entity.Id);

                if (userEntity == null)
                {
                    throw new DbEntityNotFoundException(nameof(User));
                }

                var updatedUserCourses = entity.CourseProgress
                    .ToUserCourse();

                var updatedUserMaterials = entity.MaterialLearned
                    .ToUserMaterial();

                var updatedUserPerks = entity.PerkLevel
                    .ToUserPerk();

                userEntity.MapFromUserDomain(entity,
                    updatedUserCourses,
                    updatedUserMaterials,
                    updatedUserPerks);

                _context.Update(userEntity);

                return entity;
            });
        }

        private User GetById(int id)
        {
            return _context.Users.First(u => u.Id == id);
        }
    }
}
