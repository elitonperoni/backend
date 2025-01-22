
namespace backend.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IWalletRepository WalletRepository { get; }
        IUserRepository UserRepository { get; }
        Task Commit();

    }
}
