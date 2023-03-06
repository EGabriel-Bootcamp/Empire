using BankApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        public Task<Account> Create(Account account);
        public Task<Account> GetAccount(string id);
    }
}
