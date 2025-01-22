using backend.Context;
using backend.Repository.Interfaces;

namespace backend.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private UserRepository _userRepo;
        private WalletRepository _walletRepo;
        private AppDbContext _context;

        public UnitOfWork(AppDbContext contexto)
        {
            _context = contexto;
        }

        public IUserRepository UserRepository
        {
            get { return _userRepo = _userRepo ?? new UserRepository(_context); }
        }

        public IWalletRepository WalletRepository
        {
            get { return _walletRepo = _walletRepo ?? new WalletRepository(_context); }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

    }
}
