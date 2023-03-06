using BankApp.Domain.Entity;
using BankApp.Domain.Interfaces.Repositories;
using System.Text.Json;



namespace BankApp.Infrastructure.Repositories
{
    public class TransactionRepository:ITransactionRepository
    {
        public async Task<bool> Transaction(Transaction transaction) 
        {

            var options = new JsonSerializerOptions { WriteIndented = true };
            string fileName = "Transaction.json";


            if (File.Exists(fileName))
            {
                var jsonString = File.ReadAllText(fileName);
                if (jsonString == "" || jsonString == " ")
                {
                    var newList = new List<Transaction>();
                    newList.Add(transaction);

                    var user = JsonSerializer.Serialize(newList, options);

                    File.WriteAllText(fileName, user);
                    return true;
                }

                var accounts = JsonSerializer.Deserialize<List<Transaction>>(jsonString);

                if (accounts != null)
                {
                    accounts.Add(transaction);
                }

                var allUsers = JsonSerializer.Serialize(accounts, options);

                File.WriteAllText(fileName, allUsers);
                
            }
            else
            {
                var newList = new List<Transaction>();
                newList.Add(transaction);

                var user = JsonSerializer.Serialize(newList, options);

                File.WriteAllText(fileName, user);
                return true;

            }


            return false;
        }


        public async Task<List<Transaction>> UserTransactions(string account_id)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string fileName = "Transaction.json";


            if (File.Exists(fileName))
            {
                var jsonString = File.ReadAllText(fileName);
                if (jsonString == "" || jsonString == " ")
                {
                    return null;
                }

                var accounts = JsonSerializer.Deserialize<List<Transaction>>(jsonString);

                if (accounts != null)
                {
                    return accounts.Where(x => x.Account_id == account_id).ToList();
                }

            }
            else
            {
                return null;
            }
            return null;
        }



        }
}
