using backend.Models;

namespace backend.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<User> Create(User user);
        Task<User?> GetUserById(int id);
        Task Remove(int id);
    }    
}