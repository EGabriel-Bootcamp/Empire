using ConsoleBankApp.Domain.Entity;
using ConsoleBankApp.Domain.Interfaces.IRepository;
using ConsoleBankApp.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;

        public AccountService(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }
         public async Task<Account> Create(Account account)
        {
            var result = await _accountRepository.Create(account);
            return result;
        }
        public async Task<bool> Withdraw(decimal amount, string description, string accountid)
        {
            var transaction = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                AccountId = accountid,
                Amount = amount,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            var result  = await _transactionRepository.Transaction(transaction);
            return result; 
        }
        public async Task<bool> Deposit(decimal amount, string description, string accountid)
        {
            var transaction = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                AccountId = accountid,
                Amount = amount,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            var result = await _transactionRepository.Transaction(transaction);

            return result;
        }
    }
}
