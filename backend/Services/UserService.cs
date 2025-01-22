using backend.Models;
using backend.Repository.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uof;
        public UserService(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public async Task AddUser(User user)
        {
            await _uof.UserRepository.Create(user);
        }

        public async Task DeleteUserById(int id)
        {
            await _uof.UserRepository.Remove(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _uof.UserRepository.GetAllUsers();            
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _uof.UserRepository.GetUserById(id);
        }
    }
}
