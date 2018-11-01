using System;
using System.Security.Policy;
using MenuShell.Domain;
using MenuShell.Services;
using MenuShell.View;

namespace MenuShell
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new DataBase();
            
            database.DatabaseInteract("CREATE TABLE [User] (Username varchar(100),[Password] varchar(100),Role varchar(50))");

            database.AddUser(new User(username: "admin", password: "admin", role: "admin"));
            database.AddUser(new User(username: "a", password: "a", role: "admin"));
            database.AddUser(new User(username: "user", password: "user", role: "user"));

            var ViewHandler = new ViewHandler();

            ViewHandler.MainMenu();
            
        }
    }
}
