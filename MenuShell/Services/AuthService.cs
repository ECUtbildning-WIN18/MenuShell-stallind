using System.Collections.Generic;
using MenuShell.Domain;


namespace MenuShell.Services
{
    class AuthService : IAuthService
    {
        public User Auth(string username, string password, List<User> users)
        {
            User _user = null;

            foreach (User user in users)
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
