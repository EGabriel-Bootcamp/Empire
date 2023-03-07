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
            var outsideLoop = true;
            var menuLoop = false;
            var switchLoop = true;

            do
            {
                Console.WriteLine("*******************************Welcome to Console Bank!*****************************");
                Console.WriteLine();
                Console.WriteLine("Press 1 to login or 2 to Register ");
                var x = Console.ReadLine();
                if (x != null)
                {
                   
                    if (x == "1" || x == "2")
                    {
                        //Login
                        if (x == "1")
                        {
                            Console.WriteLine("Insert Email");
                            var email = Console.ReadLine();
                            Console.WriteLine("Insert Password");
                            var password = Console.ReadLine();
                            var user = await Di._userService.Login(email, password);
                            if (user != null)
                            {
                                id = user.Id;
                                var result = await Di._accountService.GetAccount(id);
                                if(result != null) accountId = result.Id;
                            }
                        }
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
                        var result = await Di._accountService.GetAccount(id);
                        if (result != null) accountId = result.Id;
                    }
                    if(id != "")
                    {
                        menuLoop = true;
                    }
                    while (menuLoop)
                    {
                        Random rnd = new Random();
                        var value = string.Empty;

                        Console.WriteLine("Press 1 to Create an account");
                        Console.WriteLine("Press 2 to deposit");
                        Console.WriteLine("Press 3 to withdraw");
                        Console.WriteLine("Press 4 to check balance");
                        Console.WriteLine("Press 5 to get account summary");
                        Console.WriteLine("Press 6 to logout");
                        value = Console.ReadLine();
                        switchLoop = true;
                        while (switchLoop)
                        {
                            switch (value)
                            {
                                case "1":
                                    Console.Write($"Bank Name ");
                                    var name = Console.ReadLine();

                                    var account = new Account()
                                    {
                                        Id = Guid.NewGuid().ToString(),
                                        User_Id = id,
                                        AccountNumber = rnd.Next(123456789, 999999999),
                                        Name = name,
                                        CreatedAt = DateTime.Now,
                                        UpdatedAt = DateTime.Now,

                                    };
                                    var acc = await Di._accountService.Create(account);
                                    switchLoop = false;
                                    accountId = acc.Id;
                                    break;

                                case "2":
                                    Console.WriteLine($"Deposit Amount");
                                    var result = int.TryParse(Console.ReadLine(), out int amount);
                                    Console.WriteLine($"Description");
                                    var desc = Console.ReadLine();
                                    await Di._accountService.Deposit(amount, desc, accountId);

                                    if (result)
                                        Console.WriteLine("Successful");
                                    switchLoop = false;
                                    break;
                                case "3":
                                    Console.WriteLine($"Withdrawal Amount");
                                    var WithdrawalResult = int.TryParse(Console.ReadLine(), out int WithdrawalAmount);
                                    Console.WriteLine($"Description");
                                    var WithdrawalDesc = Console.ReadLine();
                                    await Di._accountService.Withdraw(WithdrawalAmount, WithdrawalDesc, accountId);
                                    if (WithdrawalResult)
                                        Console.WriteLine("Successful");
                                    switchLoop = false;
                                    break;
                                case "4":
                                    Console.Write($"Balance is:  ");
                                    var bal = await Di._transactionService.Balance(accountId);
                                    Console.WriteLine(bal);
                                    switchLoop = false;
                                    break;
                                case "5":
                                    if (accountId != "")
                                    {
                                        Console.WriteLine($"Summary");
                                        Console.WriteLine(await Di._transactionService.Summary(accountId));
                                        switchLoop = false;
                                        break;
                                    }
                                    switchLoop = false;
                                    break;

                                case "6":
                                    switchLoop = false;
                                    id = "";
                                    menuLoop = false;
                                    break;
                                default:
                                    Console.WriteLine($"Wrong Selection");
                                    switchLoop = false;
                                    break;
                            }
                        }

                    
                    }
                    if (id == "")
                        Console.WriteLine("UnAuthenticated");
                    else
                    {
                        Console.WriteLine("Please enter the right input");
                    }
                }



            } while (outsideLoop);
        }
    }
}
