using backend.Context;
using backend.Models;
using backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User> Create(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _context.Set<User>().AsNoTracking().ToListAsync();
    }

    public async Task<User?> GetUserById(int id)
    {
        return await _context.Set<User>().Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();
    }

    public async Task<User?> GetUserWithWallets(int id)
    {
        return await _context.Set<User>().Where(p => p.Id.Equals(id)).AsNoTracking().Include(p => p.Wallets).FirstOrDefaultAsync();
    }

    public async Task Remove(int id)
    {
        var user = await GetUserById(id);

        if (user is null)
            throw new Exception("User not found");

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}
