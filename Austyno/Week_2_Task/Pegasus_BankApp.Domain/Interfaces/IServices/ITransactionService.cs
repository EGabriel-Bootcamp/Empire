using Pegasus_BankApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pegasus_BankApp.Domain.Interfaces.IServices
{
    public interface ITransactionService
    {
        public Task<bool> Transaction(Transaction transaction);

        public Task<List<Transaction>> UserTransactions(string account_id);


        public Task<decimal> Balance(string account_id);

        public Task<string> Summary(string account_id);

    }
}
