using backend.Models;
using backend.Repository.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services
{
    public class WalletService : IWalletService
    {
        private readonly IUnitOfWork _uof;
        public WalletService(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public async Task AddWallet(Wallet wallet)
        {
            await _uof.WalletRepository.Create(wallet);
        }

        public async Task DeleteWalletById(int id)
        {
            await _uof.WalletRepository.Remove(id);
        }

        public async Task<List<Wallet>> GetAllWallets()
        {
            return await _uof.WalletRepository.GetAllWallets();
        }

        public async Task<List<Wallet>> GetWalletsByUserId(int usuarioid)
        {
            return await _uof.WalletRepository.GetWalletsByUserId(usuarioid);
        }
    }
}
