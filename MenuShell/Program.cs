using MenuShell.Domain;
using MenuShell.View;

namespace MenuShell
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // You need to create a table [Users] in database named MenuShell with:
            // Id INT IDENTITY PRIMARY KEY
            // Username varchar(100),
            // Password varchar(50),
            // Role varchar(10)

            using (var ForRobert = new MenuShellDbContext())
            {
                ForRobert.Users.Add(new User("admin", "secret", "admin"));
                ForRobert.SaveChanges();
            }
            
            ViewHandler.MainMenu();
        }
    }
}