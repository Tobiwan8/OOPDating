using OOPDating.Entities;

namespace OOPDating.Interfaces
{
    public interface IAccountService
    {
        List<Account> GetAccounts();
        Account GetAccountById(int id);

        void UpdateAccountPw(Account account);
        void AddAccount(Account account);
        void DeleteAccount(int ID);
    }
}
