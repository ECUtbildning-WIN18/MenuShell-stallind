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
            
            DataBase.users.Add(new User(userName: "admin", password: "admin", role: "admin"));
            DataBase.users.Add(new User(userName: "user", password: "user", role: "user"));

            Initialize.MainMenu();
            
        }
    }
}
