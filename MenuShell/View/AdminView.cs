using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using MenuShell.Domain;
using MenuShell.View;
using System.Threading;

namespace MenuShell.View
{
    public class AdminView
    {
        public static bool runningDrawMenu = true;

        public void DrawMenu(List<User> users)
        {
            
            do
            {
                Console.Clear();
                Console.WriteLine("Admin menu\n");
                Console.WriteLine("1. Add user.");
                Console.WriteLine("2. Remove user.");
                Console.WriteLine("3. List all users.");
                Console.WriteLine("4. Search user.");
                Console.WriteLine("5. Exit.");

                var choice = new AdminView();

                ConsoleKey menuChoice = Console.ReadKey(true).Key;

                switch (menuChoice)
                {
                    case ConsoleKey.D1:

                        choice.AddUser();
                        break;

                    case ConsoleKey.D2:

                       choice.RemoveUser();
                        break;

                    case ConsoleKey.D3:
                        
                        choice.ListUsers();
                        break;

                    case ConsoleKey.D4:

                        var search = new AdminUserSearch();
                        
                        search.FindUser(); 
                        break;

                    case ConsoleKey.D5: 

                        Environment.Exit(0);
                        break;

                    default:

                        Console.Clear();
                        break;
                }

            } while (runningDrawMenu);

        }

        public void AddUser()
        {
            var runningAddMenu = true;

            do
            {
            Console.Clear();
            Console.WriteLine("Admin view, add user: ");

            Console.Write("Username: ");

            var username = Console.ReadLine();

            Console.Write("Password: ");

            var password = Console.ReadLine();

            Console.Write("Role(user/admin): ");

            var role = Console.ReadLine();

            if (role == "" || password == "" || username == "")
            {
                Console.WriteLine("Fields cannot be blank");

                Thread.Sleep(2000);

                Console.Clear();
            }

            else if (role == "admin" || role == "user")
            {
               var databaseSQL = new DataBase();
               User newUser = new User(username, password, role);
               databaseSQL.AddUser(newUser);

                Console.Clear();

                Console.WriteLine($"User {username} was successfully added.");

                Thread.Sleep(2000);

                runningAddMenu = false;

                Console.Clear();
            }

            else
            {
                Console.Clear();

                Console.WriteLine("Invalid role");

                Thread.Sleep(2000);
            }
            } while (runningAddMenu);

        }

        public void RemoveUser()
        {
            var databaseSQL = new DataBase();
          
            Console.Clear();
            Console.Write("Type the username of which user to remove: ");

            var userRemoveInput = Console.ReadLine();

            var removeSuccess = databaseSQL.RemoveUser(userRemoveInput);

            if (removeSuccess == 1)
            {
               Console.WriteLine($"{userRemoveInput} was removed from the system.");
                   
               Thread.Sleep(1500);
            }
        }

        public void ListUsers()
        {
            Console.Clear();

            var getUser = new DataBase();

            getUser.GetUsers();
          
            Console.WriteLine("Press enter to return to the admin menu.");

            Console.ReadLine();

            Console.Clear();

        }
    }
}
