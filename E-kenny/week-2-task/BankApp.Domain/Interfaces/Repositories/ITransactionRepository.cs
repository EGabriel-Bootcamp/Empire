using BankApp.Domain.Entity;


namespace BankApp.Domain.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        public Task<bool> Transaction(Transaction transaction);
        public Task<List<Transaction>> UserTransactions(string account_id);
    }
}
