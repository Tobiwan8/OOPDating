using OOPDating.Entities;
using OOPDating.Interfaces;
using OOPDating.Global;

namespace OOPDating.Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _repository;

        public AccountService(IAccountRepository accountRepository) 
        {
            _repository = accountRepository;
        }


        public void AddAccount(Account account)
        {
            _repository.AddAccount(account);
        }

        public void DeleteAccount(Account account)
        {
            _repository.DeleteAccount(account);
        }

        public Account GetAccount(string accountName)
        {
            Account FindDBAccount= _repository.GetAccount(accountName);
            CurrentLoginAccount.ID = FindDBAccount.ID;
            CurrentLoginAccount.AccountName = FindDBAccount.AccountName;
            CurrentLoginAccount.Password = FindDBAccount.Password;
            return FindDBAccount;
        }

        public List<Account> GetAccounts()
        {
            var accounts = _repository.GetAccounts();
            return accounts;
        }
    }
}