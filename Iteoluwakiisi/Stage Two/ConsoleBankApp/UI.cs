using ConsoleBankApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp
{
    public class UI
    {
        public static async Task Start()
        {
            DI Di = new DI();
            var id = string.Empty;
            var accountId = string.Empty;


            Console.WriteLine("Welcome to Pegasus Bank!");
            Console.WriteLine("Press 1 to login or 2 to Register ");
            var x = Console.ReadLine();
            if (x != null)
            {
                if (x == "1")
                {
                    Console.WriteLine("Insert Email");
                    var email = Console.ReadLine();
                    Console.WriteLine("Insert Password");
                    var password = Console.ReadLine();
                    var user = await Di._userService.Login(email, password);
                    if (user != null) id = user.Id;

                }
                else if (x == "2")
                {
                    Console.WriteLine("Insert Name");
                    var name = Console.ReadLine();
                    Console.WriteLine("Insert Email");
                    var email = Console.ReadLine();
                    Console.WriteLine("Insert Password");
                    var password = Console.ReadLine();

                    var newUser = new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = email,
                        Password = password,
                        Name = name,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    };
                    var user = await Di._userService.Register(newUser);
                    if (user != null) id = user.Id;
                }
                else
                {
                    Console.WriteLine("Please enter the right input");
                }
            }
        }
    }
}
