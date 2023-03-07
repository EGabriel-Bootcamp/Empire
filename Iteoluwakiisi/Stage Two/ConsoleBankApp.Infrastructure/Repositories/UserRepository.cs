using ConsoleBankApp.Domain.Entity;
using ConsoleBankApp.Domain.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleBankApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> GetUser(string id)
        {
            string fileName = "User.json";

            var jsonString = File.ReadAllText(fileName);
            var users = JsonSerializer.Deserialize<List<User>>(jsonString);

            if (users != null)
            {
                var result = users.FirstOrDefault(x => x.Id == id);

                if (result == null) return null;

                return result;
            }

            return null;
        }

        public async Task<User> Login(string email, string password)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string fileName = "User.json";


            var jsonString = File.ReadAllText(fileName);
            var users = JsonSerializer.Deserialize<List<User>>(jsonString);

            if (users != null)
            {
                var result = users.FirstOrDefault(x => x.Email == email && x.Password == password);

                if (result == null) return null;

                return result;

            }
            return null;
        }

        public async Task<User> Register(User user)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string fileName = "User.json";

            if (File.Exists(fileName))
            {
                var jsonString = File.ReadAllText(fileName);
                if (jsonString == "" || jsonString == " ")
                {
                    var newList = new List<User>();
                    newList.Add(user);


                    var firstUser = JsonSerializer.Serialize(newList, options);

                    File.WriteAllText(fileName, firstUser);
                    return user;
                }

                var users = JsonSerializer.Deserialize<List<User>>(jsonString);

                if (users != null)
                {
                    users.Add(user);
                }

                var allUsers = JsonSerializer.Serialize(users, options);

                File.WriteAllText(fileName, allUsers);
                return user;
            }
            else
            {
                var newList = new List<User>();
                newList.Add(user);


                var allUsers = JsonSerializer.Serialize(newList, options);

                File.WriteAllText(fileName, allUsers);
                return user;

            }
            return null;
        } 

    }
}

     
