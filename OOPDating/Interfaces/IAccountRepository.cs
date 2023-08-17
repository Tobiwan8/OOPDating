using OOPDating.Entities;

namespace OOPDating.Interfaces
{
    public interface IAccountRepository
    {
        List<Account> GetAccounts();
        Account GetAccount(int id);

        bool UpdateAccountPw(Account account);
        bool AddAccount(Account account);
        bool DeleteAccount(Account account);
    }
}
