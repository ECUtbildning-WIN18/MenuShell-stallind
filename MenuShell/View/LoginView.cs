using System;
using System.Threading;
using MenuShell.Domain;
using MenuShell.Services;

namespace MenuShell.View
{
    internal class LoginView
    {
        public void Login()
        {
            Console.Write("Username: ");

            var username = Console.ReadLine();

            Console.Write("Password: ");

            var password = Console.ReadLine();

            var EFSQL = new AuthService();

            var loggedOnUser = EFSQL.Auth(username, password);

            if (loggedOnUser != null)
            {
                Console.Clear();

                Console.WriteLine($"Welcome {username}");

                Console.WriteLine($"Role: {loggedOnUser.Role}");

                Thread.Sleep(1000);

                if (loggedOnUser.Role == "admin")
                {
                    Console.Clear();

                    var adminView = new AdminView();

                    adminView.DrawMenu(DataBase.users);
                }

                else if (loggedOnUser.Role == "user")
                {
                    Console.Clear();

                    var userMenu = new UserView();

                    userMenu.DrawMenu();
                }
            }
            else
            {
                Console.Clear();

                Console.WriteLine("Wrong username or password, try again.");

                Thread.Sleep(1000);
            }
        }
    }
}