using OOPDating.Entities;
using OOPDating.Interfaces;

namespace OOPDating.Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _repository;
        public Account CurrentAccount { get; set; }

        public AccountService()
        {
            CurrentAccount = new Account();
        }

        public AccountService(IAccountRepository accountRepository) 
        {
            _repository = accountRepository;
        }


        public void AddAccount(Account account)
        {
            _repository.AddAccount(account);
        }

        public void DeleteAccount(string accountName)
        {
            var account = _repository.GetAccount(accountName);
            _repository.DeleteAccount(account);
        }

        public Account GetAccount(string accountName)
        {
            Account FindDBAccount= _repository.GetAccount(accountName);
            CurrentAccount = FindDBAccount;
            return FindDBAccount;
        }

        public List<Account> GetAccounts()
        {
            var accounts = _repository.GetAccounts();
            return accounts;
        }

        public void UpdateAccount(Account account)
        {
            if(account.AccountName != null)
            {
                var dbAccount = _repository.GetAccount(account.AccountName);
                dbAccount.Password = account.Password;
                _repository.UpdateAccountPw(dbAccount);
            }
        }
    }
}