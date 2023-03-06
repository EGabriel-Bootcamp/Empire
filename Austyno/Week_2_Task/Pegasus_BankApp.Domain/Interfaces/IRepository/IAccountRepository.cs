using Pegasus_BankApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pegasus_BankApp.Domain.Interfaces.IRepository
{
    public interface IAccountRepository
    {
        public Task<Account> Create(Account account);

        public Task<Account> GetAccount(string id);

    }
}
