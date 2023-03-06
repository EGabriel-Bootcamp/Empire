using Pegasus_BankApp.Domain.Entity;
using Pegasus_BankApp.Domain.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pegasus_BankApp.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public async Task<Account> Create(Account account)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string fileName = "Account.json";


            if (File.Exists(fileName))
            {
                var jsonString = File.ReadAllText(fileName);
                if (jsonString == "" || jsonString == " ")
                {
                    var newList = new List<Account>();
                    newList.Add(account);

                    var user = JsonSerializer.Serialize(newList, options);

                    File.WriteAllText(fileName, user);
                    return account;
                }

                var accounts = JsonSerializer.Deserialize<List<Account>>(jsonString);

                if (accounts != null)
                {
                    accounts.Add(account);
                }

                var allUsers = JsonSerializer.Serialize(accounts, options);

                File.WriteAllText(fileName, allUsers);
                Console.WriteLine(File.ReadAllText(fileName));
            }
            else
            {
                var newList = new List<Account>();
                newList.Add(account);

                var user = JsonSerializer.Serialize(newList, options);

                File.WriteAllText(fileName, user);
                return account;

            }


            return null;
        }


        public async Task<Account> GetAccount(string id)
        {
            string fileName = "Account.json";

            var jsonString = File.ReadAllText(fileName);
            var accounts = JsonSerializer.Deserialize<List<Account>>(jsonString);

            if (accounts != null)
            {
                var result = accounts.FirstOrDefault(x => x.Id == id);

                if (result == null) return null;

                return result;
            }

            return null;
        }

    }
}
