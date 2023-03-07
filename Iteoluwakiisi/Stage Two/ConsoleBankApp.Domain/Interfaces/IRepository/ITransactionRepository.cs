using ConsoleBankApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Domain.Interfaces.IRepository
{
    public interface ITransactionRepository
    {
        public Task<bool> Transaction(Transaction transaction);

        public Task<List<Transaction>> UserTransactions(string accountid);


        // public Task<List<Transaction>> TransactionList(List<Transaction> transactionList);
    }
}
