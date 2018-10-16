using MenuShell.Domain;
using MenuShell.Services;
using MenuShell.View;

namespace MenuShell
{
    class Program
    {
        static void Main(string[] args)
        {
            var Initialize = new ViewHandler();

            var user = new User(userName:"admin", password:"admin", role:"admin");

            Initialize.MainMenu();

            if (user.Role == "admin")
            {
                var admin = new AdminMenu();
                admin.AdminMain();
            }
            
        }
    }
}
