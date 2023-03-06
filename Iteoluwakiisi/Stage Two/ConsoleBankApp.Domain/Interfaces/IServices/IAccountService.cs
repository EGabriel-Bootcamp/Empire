using ConsoleBankApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Domain.Interfaces.IServices
{
    public interface IAccountService
    {
        public Task<Account> Create(Account account);
        public Task<bool> Withdraw(decimal amount, string description, string accountid);
        public Task<bool> Deposit(decimal amount, string description, string accountid);
    }
}
