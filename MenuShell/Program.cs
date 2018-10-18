using MenuShell.Domain;
using MenuShell.Services;
using MenuShell.View;

namespace MenuShell
{
    class Program
    {
        static void Main(string[] args)
        {

            DataBase.users.Add(new User(userName: "admin", password: "admin", role: "admin"));
            DataBase.users.Add(new User(userName: "user", password: "user", role: "user"));

            var ViewHandler = new ViewHandler();

            ViewHandler.MainMenu();
            
        }
    }
}
