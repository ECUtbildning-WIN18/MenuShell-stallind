using System.Collections.Generic;
using MenuShell.Domain;

namespace MenuShell.Services
{
    class AuthService : IAuthService
    {
        public User Auth(string username, string password)
        {
            User _user = null;

            foreach (User user in DataBase.users)
            {
                if (user.UserName == username && user.Password == password)
                {
                    _user = user;
                    break;
                }
            }
            return _user;
        }
    }
}
