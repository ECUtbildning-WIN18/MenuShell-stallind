using System.Collections.Generic;
using MenuShell.Domain;

namespace MenuShell.Services
{
    class AuthService : IAuthService
    {
        public User Auth(string username, string password)
        {
            var databaseUsers = new DataBase();

            databaseUsers.GetUsers();

            return null;
        } 
    }
}
