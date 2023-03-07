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
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<bool> Transaction(Transaction transaction)
        {
            var result = await _transactionRepository.Transaction(transaction);
            return true;
        }
        public async Task<List<Transaction>> UserTransactions(string accountid)
        {
            var result = await _transactionRepository.UserTransactions(accountid);
            return result;
        }

        public async Task<decimal> Balance(string accountid)
        {

            var result = await _transactionRepository.UserTransactions(accountid);
            decimal bal = 0;
            foreach (var transaction in result)
            {
                bal += transaction.Amount;
            }
            return bal;
        }

        public async Task<string> Summary(string accountid)
        {
            var result = await _transactionRepository.UserTransactions(accountid);
            var stringbulder = new StringBuilder();
            stringbulder.AppendLine($"------------------------------------------------------------------------------------");
            stringbulder.AppendLine($"|{"Amount",-15}|{"Description",-40}|{"CreatedAt",-25}|");
            decimal bal = 0;
            foreach (var transaction in result)
            {
                stringbulder.AppendLine($"------------------------------------------------------------------------------------");
                stringbulder.AppendLine($"|{transaction.Amount,-15}|{transaction.Description,-40}|{transaction.CreatedAt,-25}|");
                bal += transaction.Amount;
            }
            stringbulder.AppendLine($"|----------------------------------------------------------------------------------|");
            stringbulder.AppendLine($" Balance {bal,-15}");
            stringbulder.AppendLine($"|----------------------------------------------------------------------------------|");
            return stringbulder.ToString();
        }
    }
}
