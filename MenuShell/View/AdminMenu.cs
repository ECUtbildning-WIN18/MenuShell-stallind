using System;
using MenuShell.Domain;

namespace MenuShell.View
{
    public class AdminMenu 
    {
        public void AdminMain()
        {
            Console.WriteLine("Admin menu\n");
            Console.WriteLine("1. Add user.");
            Console.WriteLine("2. Remove user.");
            Console.WriteLine("3 List all users.");
        }
        public User AddUser(string username, string password, string role)
        {
            var user = new User(username, password, role);
            Console.WriteLine("Admin view, add user");
            Console.Write("Username: ");
            username = Console.ReadLine();

            Console.Write("Password: ");
            password = Console.ReadLine();

            Console.Write("Role(user/admin): ");
            role = Console.ReadLine();

            return user;

        }

        public void RemoveUser()
        {

        }

        public void ListUsers()
        {

        }

    }
}
