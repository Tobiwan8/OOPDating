using OOPDating.Entities;
using OOPDating.Services;

namespace OOPDating.Interfaces
{
    public interface IAccountService
    {
        Account CurrentAccount { get; set; }

        List<Account> GetAccounts();

        Account GetAccount(string accountName);

        void UpdateAccount(Account account);

        void AddAccount(Account account);

        void DeleteAccount(string accountName);
    }
}
