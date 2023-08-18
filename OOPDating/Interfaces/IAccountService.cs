using OOPDating.Entities;

namespace OOPDating.Interfaces
{
    public interface IAccountService
    {
        List<Account> GetAccounts();

        Account GetAccount(string accountName);

        void UpdateAccount(Account account);

        void AddAccount(Account account);

        void DeleteAccount(string accountName);
    }
}
