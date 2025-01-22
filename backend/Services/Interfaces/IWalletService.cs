
using backend.Models;

namespace backend.Services.Interfaces
{
    public interface IWalletService
    {
        Task AddWallet(Wallet wallet);
        Task DeleteWalletById(int id);
        Task<List<Wallet>> GetAllWallets();
        Task<List<Wallet>> GetWalletsByUserId(int usuarioid);
    }
}
