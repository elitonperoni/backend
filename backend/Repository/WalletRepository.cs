using backend.Context;
using backend.Models;
using backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository;

public class WalletRepository : Repository<Wallet>, IWalletRepository
{    
    public WalletRepository(AppDbContext context): base(context)
    {
    }

    public async Task<Wallet> Create(Wallet wallet)
    {
        _context.Wallets.Add(wallet);
        await _context.SaveChangesAsync();
        return wallet;
    }

    public async Task<List<Wallet>> GetAllWallets()
    {
        return await _context.Set<Wallet>().AsNoTracking().ToListAsync();  
    }

    public async Task<List<Wallet>> GetWalletsByUserId(int userId)
    {
        return await _context.Set<Wallet>().Where(p => p.UserId.Equals(userId)).ToListAsync();
    }

    public async Task Remove(int id)
    {
        var wallet = await GetById(id);

        if (wallet is null)
            throw new Exception("Wallet not found");

        _context.Wallets.Remove(wallet);
        await _context.SaveChangesAsync();
    }

    public async Task<Wallet?> GetById(int id)
    {
        return await _context.Wallets.Where(p => p.Id == id).FirstOrDefaultAsync();
    }
}
