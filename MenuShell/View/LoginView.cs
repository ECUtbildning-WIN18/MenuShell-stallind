using System;
using MenuShell.Services;

namespace MenuShell.View
{
    class LoginView
    {

        public void Login()
        {
            var authService = new AuthService();
           
            Console.Write("Username: ");
            var username = Console.ReadLine();

            Console.Write("Password: ");
            var password = Console.ReadLine();

            authService.Auth(username, password);

        }
    }
}
