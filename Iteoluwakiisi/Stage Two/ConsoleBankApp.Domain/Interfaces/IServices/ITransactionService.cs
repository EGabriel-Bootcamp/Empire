using ConsoleBankApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Domain.Interfaces.IServices
{
    public interface ITransactionService
    {
        public Task<bool> Transaction(Transaction transaction);
        public Task<List<Transaction>> UserTransactions(string accountid);
        public Task<decimal> Balance(string accountid);

        public Task<string> Summary(string accountid);

    }
}
