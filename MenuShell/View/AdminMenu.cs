using System;
using System.Collections.Generic;
using MenuShell.Domain;
using MenuShell.View;

namespace MenuShell.View
{
    public class AdminMenu 
    {
        public void AdminMain()
        {

            do
            {
                Console.WriteLine("Admin menu\n");
                Console.WriteLine("1. Add user.");
                Console.WriteLine("2. Remove user.");
                Console.WriteLine("3. List all users.");
                Console.WriteLine("4. Exit.");

                var choice = new AdminMenu();

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
                        Environment.Exit(0);
                        break;

                  
                }

            } while (true);

        }


        public void AddUser(string username, string password, string role, List<User> users)
        {
            var user = new User(username, password, role);

            Console.WriteLine("Admin view, add user");

            Console.Write("Username: ");

            username = Console.ReadLine();

            Console.Write("Password: ");

            password = Console.ReadLine();

            Console.Write("Role(user/admin): ");

            role = Console.ReadLine();

            users.Add(new User(username, password, role));

        }

        public void RemoveUser(List<User> users)
        {
            
            foreach (User user in users)
            {
                Console.WriteLine($" Username:{user.UserName}\n");

                Console.Write("Type the username of which user to remove: ");

                User toBeRemoved = Console.ReadLine();  // Hur fixa?

                users.Remove(toBeRemoved);

            }
        }

        public void ListUsers(List<User> users)
        {

            foreach (User user in users)
            {
                Console.WriteLine($" Username:{user.UserName} Role:{user.Role}\n");
            }

            Console.WriteLine("Press any key to return to the admin menu.");

            Console.ReadLine();

            var GoBack = new AdminMenu();

            GoBack.AdminMain();
        }

    }
}
