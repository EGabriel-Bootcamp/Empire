using BankApp.Domain.Entity;
using BankApp.Domain.Interfaces.Repositories;
using BankApp.Domain.Interfaces.Services;


namespace BankApp.Core.Services
{
    public class AccountService:IAccountService
    {
        private readonly IAccountRepository _accountRepo;
        private readonly ITransactionRepository _transactionRepo;

        public AccountService(IAccountRepository accountRepo, ITransactionRepository transactionRepo) 
        {
            _accountRepo= accountRepo;
            _transactionRepo= transactionRepo;
        }
        public async Task<Account> Create(Account account)
        {
            var result = await _accountRepo.Create(account);
            return result;
        }

        public async Task<bool> Withdraw(decimal amount, string description, string account_id)
        {
            var transaction = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                Account_id = account_id,
                Description= description,
                Amount = -amount,
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now,
            };

            var result = await _transactionRepo.Transaction(transaction);

            return result;
        }

        public async Task<bool> Deposit(decimal amount, string description, string account_id)
        {
            var transaction = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                Account_id = account_id,
                Amount = amount,
                Description = description,
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now,
            };
            var result = await _transactionRepo.Transaction(transaction);

            return result;
        }

        public async Task<Account> GetAccount(string id)
        {
            var result = await _accountRepo.GetAccount(id);
            return result;
        }



    }
}
