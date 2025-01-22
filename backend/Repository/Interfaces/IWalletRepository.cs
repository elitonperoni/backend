
using backend.Models;

namespace backend.Repository.Interfaces
{
    public interface IWalletRepository : IRepository<Wallet>
    {
        Task<List<Wallet>> GetAllWallets();
        Task<List<Wallet>> GetWalletsByUserId(int usuarioid);

        Task<Wallet> Create(Wallet wallet);

        Task Remove (int id);
    }
}
