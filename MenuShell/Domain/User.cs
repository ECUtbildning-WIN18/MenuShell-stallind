using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuShell.View;

namespace MenuShell.Domain
{
    public class User 
    {
        public string UserName { get; }

        public string Password { get; }

        public string Role { get; }

        public User(string userName, string password, string role)
        {
            UserName = userName;
            Password = password;
            Role = role;
        }
    }
}
