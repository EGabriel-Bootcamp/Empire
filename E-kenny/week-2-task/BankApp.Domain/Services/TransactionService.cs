using BankApp.Domain.Entity;
using BankApp.Domain.Interfaces.Repositories;
using BankApp.Domain.Interfaces.Services;
using System.Text;

namespace BankApp.Core.Services
{
    public class TransactionService:ITransactionService
    {
        private readonly ITransactionRepository _transactionRepo;
        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepo = transactionRepository;
        }
        public async Task<bool> Transaction(Transaction transaction)
        {
            var result = await _transactionRepo.Transaction(transaction);
            return true;
        }

        public async Task<List<Transaction>> UserTransactions(string account_id)
        {
            var result = await _transactionRepo.UserTransactions(account_id);
            return result;
        }

        public async Task<decimal> Balance(string account_id)
        {

            var result = await _transactionRepo.UserTransactions(account_id);
            decimal bal = 0;
            foreach (var transaction in result)
            {
                bal += transaction.Amount;
            }
            return bal;
        }

        public async Task<string> Summary(string account_id)
        {
            var result = await _transactionRepo.UserTransactions(account_id);
            var stringbulder = new StringBuilder();
            stringbulder.AppendLine($"------------------------------------------------------------------------------------");
            stringbulder.AppendLine($"|{"Amount", -15}|{"Description", -40}|{"Created_at", -25}|");
            decimal bal = 0;
            foreach (var transaction in result)
            {
                stringbulder.AppendLine($"------------------------------------------------------------------------------------");
                stringbulder.AppendLine($"|{transaction.Amount, -15}|{transaction.Description, -40}|{transaction.Created_at,-25}|");
                bal += transaction.Amount;
            }
            stringbulder.AppendLine($"|----------------------------------------------------------------------------------|");
            stringbulder.AppendLine($" Balance {bal, -15}");
            stringbulder.AppendLine($"|----------------------------------------------------------------------------------|");
            return stringbulder.ToString();
        }


    }
}
