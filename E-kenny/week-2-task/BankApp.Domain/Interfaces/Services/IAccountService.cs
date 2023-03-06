using BankApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain.Interfaces.Services
{
    public interface IAccountService
    {
        public Task<Account> Create(Account account);
        public Task<bool> Withdraw(decimal amount, string description, string account_id);
        public Task<bool> Deposit(decimal amount, string description, string account_id);
        public Task<Account> GetAccount(string id);
    }
}
