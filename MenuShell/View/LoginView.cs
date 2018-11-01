using System;
using MenuShell.Services;
using MenuShell.Domain;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Threading;

namespace MenuShell.View
{
    class LoginView 
    {
       
        public void Login()
        {
            Console.Write("Username: ");

            var username = Console.ReadLine();

            Console.Write("Password: ");

            var password = Console.ReadLine();

            var databaseSQL = new DataBase();

            var LoggedOnUser = databaseSQL.Validate(username, password);
          
            if (LoggedOnUser != null)
            {
                Console.Clear();

                Console.WriteLine($"Welcome {username}");

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
                Console.Clear();

                Console.WriteLine("Wrong username or password, try again.");

                Thread.Sleep(1000);
            }
        }
    }
}
