using System;
using System.Collections.Generic;
using MenuShell.Domain;
using MenuShell.View;

namespace MenuShell.View
{
    public class AdminView 
    {
        public void DrawMenu(List<User> users)
        {

            do
            {
                Console.WriteLine("Admin menu\n");
                Console.WriteLine("1. Add user.");
                Console.WriteLine("2. Remove user.");
                Console.WriteLine("3. List all users.");
                Console.WriteLine("4. Exit.");

                var choice = new AdminView();

                ConsoleKey menuChoice = Console.ReadKey(true).Key;

                switch (menuChoice)
                {
                    case ConsoleKey.D1:
                        choice.AddUser(users);
                        break;

                    case ConsoleKey.D2:
                        choice.RemoveUser(users);
                        break;

                    case ConsoleKey.D3:
                        choice.ListUsers(users);
                        break;

                    case ConsoleKey.D4:
                        Environment.Exit(0);
                        break;

                }

            } while (true);

        }

        public void AddUser(List<User> users)
        {
            Console.Clear();
            Console.WriteLine("Admin view, add user: ");

            Console.Write("Username: ");

            var username = Console.ReadLine();

            Console.Write("Password: ");

            var password = Console.ReadLine();

            Console.Write("Role(user/admin): ");

            var role = Console.ReadLine();
           
            users.Add(new User(username, password, role));
            Console.Clear();

        }

        public void RemoveUser(List<User> users)
        {
            Console.Clear();
            User userToBeRemoved = null;
            foreach (User user in users)
            {
                Console.WriteLine($" Username:{user.UserName}\n");

                Console.Write("Type the username of which user to remove: ");

                string toBeRemoved = Console.ReadLine();  
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].UserName == toBeRemoved)
                    {
                       userToBeRemoved = users[i];
                       break;
                    }
                }
            }
            if (userToBeRemoved != null)
            users.Remove(userToBeRemoved);
        }

        public void ListUsers(List<User> users)
        {
            Console.Clear();
            foreach (User user in users)
            {
                Console.WriteLine($" Username:{user.UserName} Role:{user.Role}\n");
            }

            Console.WriteLine("Press any key to return to the admin menu.");

            Console.ReadLine();

            var GoBack = new AdminView();

          //  GoBack.DrawMenu();
        }

    }
}
