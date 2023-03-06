using Pegasus_BankApp.Domain.Entity;
using Pegasus_BankApp.Domain.Interfaces.IRepository;
using Pegasus_BankApp.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pegasus_BankApp.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepo;
        private readonly ITransactionRepository _transactionRepo;

        public AccountService(IAccountRepository accountRepo, ITransactionRepository transactionRepo)
        {
            _accountRepo = accountRepo;
            _transactionRepo = transactionRepo;
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
                Account_Id = account_id,
                Amount = -amount,
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,
            };

            var result = await _transactionRepo.Transaction(transaction);

            return result;
        }

        public async Task<bool> Deposit(decimal amount, string description, string account_id)
        {
            var transaction = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                Account_Id = account_id,
                Amount = amount,
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,
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
