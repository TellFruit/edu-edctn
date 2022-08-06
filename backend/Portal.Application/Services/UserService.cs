namespace Portal.Application.Services
{
    internal class UserService : BaseModelService<User>, IModelService<UserDTO>
    {
        public UserService(IGenericRepository<User> repository, IMapper mapper)
            : base(repository, mapper) {}

        public async Task<UserDTO> Create(UserDTO entity)
        {
            var user = _mapper.Map<User>(entity);

            user.CreatedAt = DateTime.Now;

            await _repository.Create(user);
            await _repository.SaveChanges();

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<int> Delete(int id)
        {
            var users = await _repository.Read();
            var toDelete = users.FirstOrDefault(a => a.Id.Equals(id));

            if (toDelete is null)
            {
                throw new EntityNotFoundException(nameof(Perk));
            }

            return await _repository.Delete(toDelete);
        }

        public async Task<ICollection<UserDTO>> GetAll()
        {
            var users = await _repository.Read();

            return _mapper.Map<ICollection<UserDTO>>(users);
        }

        public async Task<UserDTO> Update(UserDTO entity)
        {
            var users = await _repository.Read();

            var toUpdate = users.FirstOrDefault(a => a.Id.Equals(entity.Id));
            var data = _mapper.Map<User>(entity);

            if (toUpdate is null)
            {
                throw new EntityNotFoundException(nameof(Book));
            }

            toUpdate.FirstName = data.FirstName;
            toUpdate.LastName = data.LastName;
            toUpdate.Email = data.Email;
            toUpdate.Password = data.Password;
            toUpdate.Roles = data.Roles;

            toUpdate.UpdatedAt = DateTime.Now;

            await _repository.Update(toUpdate);

            return _mapper.Map<UserDTO>(toUpdate);
        }
    }
}
