using OOPDating.Entities;
using OOPDating.Services;

namespace OOPDating.Interfaces
{
    public interface IAccountService
    {
        List<Account> GetAccounts();

        Account GetAccount(string accountName);

        void AddAccount(Account account);

        void DeleteAccount(Account account);
    }
}
