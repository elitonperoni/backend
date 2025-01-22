using backend.Models;
using backend.Repository.Interfaces;

namespace backend.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task AddUser(User user);
        Task<User?> GetUserById(int id);
        Task DeleteUserById(int id);
    }
}
