using ConsoleBankApp.Domain.Entity;
using ConsoleBankApp.Domain.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleBankApp.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
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
                Console.WriteLine(File.ReadAllText(fileName));
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
    }
}
