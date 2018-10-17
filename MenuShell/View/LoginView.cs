using System;
using MenuShell.Services;
using MenuShell.Domain;
using System.Collections.Generic;
using System.Threading;

namespace MenuShell.View
{
    class LoginView : AuthService
    {
       
        public void Login()
        {
            var authService = new AuthService(); 

            Console.Write("Username: ");

            var username = Console.ReadLine();

            Console.Write("Password: ");

            var password = Console.ReadLine();

            var LoggedOnUser = authService.Auth(username, password);

            if (LoggedOnUser != null)
            {
                Console.Clear();

                Console.WriteLine("Welcome!");

                Console.WriteLine($"Role: {LoggedOnUser.Role}");

                Thread.Sleep(1000);

                if (LoggedOnUser.Role == "admin")
                {
                    Console.Clear();

                    var AdminView = new AdminView();

                    AdminView.DrawMenu(DataBase.users);

                }

                else if (LoggedOnUser.Role == "user")
                {
                    Console.Clear();

                    var userMenu = new UserView();

                    userMenu.DrawMenu();
                }
            }
            else
            {
                Console.WriteLine("Wrong username or password!");
            }
        }
    }
}
