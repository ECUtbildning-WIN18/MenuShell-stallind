using System;
using System.Collections.Generic;
using MenuShell.Domain;
using MenuShell.View;
using System.Threading;

namespace MenuShell.View
{
    public class AdminView 
    {
        public void DrawMenu(List<User> users)
        {

            do
            {
                Console.Clear();
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

                    default:

                        Console.Clear();

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

            Console.WriteLine($"User {username} was successfully added.");

            Thread.Sleep(2000);

            Console.Clear();

        }

        public void RemoveUser(List<User> users)
        {
            User userToBeRemoved = null;

            bool loop = true;

            do
            {

                foreach (User user in users)
                {
                    Console.Clear();

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

                    if (userToBeRemoved != null)
                    {
                        users.Remove(userToBeRemoved);

                        Console.WriteLine($"{toBeRemoved} was removed from the system.");

                        Thread.Sleep(1000);

                        loop = false;

                        break;
                    }

                    else if (toBeRemoved == "") 
                    {
                        loop = false;
                    }

                    else
                    {
                        Console.Clear();

                        Console.WriteLine("User not found, try again!");

                        Thread.Sleep(1000);
                    }
                }
            } while (loop);

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

            Console.Clear();

            GoBack.DrawMenu(users);
        }

    }
}
