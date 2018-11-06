using System.Collections.Generic;
using System.Linq;
using MenuShell.Domain;

namespace MenuShell.Services
{
    internal class AuthService : IAuthService
    {
        public User Auth(string username, string password)
        {
            var userList = LoadUsers();
            var user = userList.Find(x => x.Username == username && x.Password == password);
            return user;
        }

        public List<User> LoadUsers()
        {
            using (var db = new MenuShellDbContext())
            {
                return db.Users.ToList();
            }
        }
    }
}