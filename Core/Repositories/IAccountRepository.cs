using Core.Entities;

namespace Core.Repositories
{
    public interface IAccountRepository
    {
        Account GetAccountById(int id);

        Account GetAccountByEmail(string email);
        void AddAccount(string email, string password);
    }
}
