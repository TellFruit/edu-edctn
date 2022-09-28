namespace Portal.Application.Services
{
    internal class UserService : BaseModelService<UserDomain>, IUserService
    {
        public UserService(IGenericRepository<UserDomain> repository, IMapper mapper)
            : base(repository, mapper) {}

        public async Task<UserDTO> Create(UserDTO entity)
        {
            if (entity.Validate(new UserValidator()))
            {
                return new UserDTO();
            }

            var user = _mapper.Map<UserDomain>(entity);

            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;

            await _repository.Create(user);
            _repository.SaveChanges();

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<int> Delete(int id)
        {
            var users = await _repository.Read();
            var toDelete = users.FirstOrDefault(a => a.Id.Equals(id));

            if (toDelete is null)
            {
                throw new EntityNotFoundException(nameof(UserDomain));
            }

            int result = await _repository.Delete(toDelete);
            _repository.SaveChanges();

            return result;
        }

        public async Task<ICollection<UserDTO>> GetAll()
        {
            var users = await _repository.Read();

            return _mapper.Map<ICollection<UserDTO>>(users);
        }

        public async Task<UserDTO> GetById(int id)
        {
            var users = await _repository.Read();

            var wantedUser = users.FirstOrDefault(c => c.Id.Equals(id));

            return _mapper.Map<UserDTO>(wantedUser);
        }

        public async Task<ICollection<UserDTO>> GetBySpec(ISpecification<UserDomain> specification)
        {
            var users = await _repository.Read(specification);

            return _mapper.Map<ICollection<UserDTO>>(users);
        }

        public async Task<UserDTO> Update(UserDTO entity)
        {
            if (entity.Validate(new UserValidator()))
            {
                return new UserDTO();
            }

            var users = await _repository.Read();

            var toUpdate = users.FirstOrDefault(a => a.Id.Equals(entity.Id));
            var data = _mapper.Map<UserDomain>(entity);

            if (toUpdate is null)
            {
                throw new EntityNotFoundException(nameof(UserDomain));
            }

            toUpdate.FirstName = data.FirstName;
            toUpdate.LastName = data.LastName;
            toUpdate.Email = data.Email;
            toUpdate.Password = data.Password;
            toUpdate.Role = data.Role;

            toUpdate.UpdatedAt = DateTime.Now;

            await _repository.Update(toUpdate);
            _repository.SaveChanges();

            return _mapper.Map<UserDTO>(toUpdate);
        }
    }
}
