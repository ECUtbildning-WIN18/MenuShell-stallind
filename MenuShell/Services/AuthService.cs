using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuShell.Domain;
using MenuShell.View;

namespace MenuShell.Services
{
    class AuthService
    {

        public void Auth(string userName, string password, string role)
        {

            // check if user is part of list users
           var user = AuthService (username, password);

            if (user != null)
            {
                Console.WriteLine("Welcome!");
                Console.WriteLine($"Role: {user.Role}");
            }
            else
            {
                Console.WriteLine("Wrong username or password!");
            }
            
        }
    }
}
