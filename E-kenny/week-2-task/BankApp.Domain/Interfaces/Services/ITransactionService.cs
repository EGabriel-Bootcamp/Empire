using BankApp.Domain.Entity;


namespace BankApp.Domain.Interfaces.Services
{
    public interface ITransactionService
    {
        public Task<bool> Transaction(Transaction transaction);
        public Task<List<Transaction>> UserTransactions(string account_id);
        public Task<decimal> Balance(string account_id);
        public Task<string> Summary(string account_id);
    }
}