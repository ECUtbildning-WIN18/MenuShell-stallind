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
            var admin = new User(userName:"admin", password:"admin", role:"admin");
            Initialize.MainMenu();
        }
    }
}
