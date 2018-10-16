using System;
using MenuShell.Services;
using MenuShell.Domain;
using System.Collections.Generic;

namespace MenuShell.View
{
    class LoginView : AuthService
    {
       
        public void Login()
        {
            var LoggedOnUser = new AuthService(); // FEL

            var users = new List<User>();
            {
                users.Add(new User(userName: "admin", password: "admin", role: "admin"));
                users.Add(new User(userName: "user", password: "user", role: "user"));
            }

            Console.Write("Username: ");
            var username = Console.ReadLine();

            Console.Write("Password: ");
            var password = Console.ReadLine();

            LoggedOnUser.Auth(username, password, users);


            if (LoggedOnUser != null)
            {
                Console.WriteLine("Welcome!");
                //Console.WriteLine($"Role: {User.Role}");
            }
            else
            {
                Console.WriteLine("Wrong username or password!");
            }


        }
    }
}
