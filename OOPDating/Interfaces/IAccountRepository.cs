using OOPDating.Entities;

namespace OOPDating.Interfaces
{
    public interface IAccountRepository
    {
        bool AddAccount(Account account);
        bool DeleteAccount(Account account);
        public Account GetAccount(string AccountName);
        List<Account> GetAccounts();
    }
}
