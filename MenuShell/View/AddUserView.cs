using System;
using System.Threading;
using MenuShell.Domain;

namespace MenuShell.View
{
    public class AddUserView
    {
        public static void AddUser()
        {
            using (var db = new MenuShellDbContext())
            {
                var runningAddMenu = true;

                do
                {
                    Console.Clear();
                    Console.WriteLine("Admin view, add user: ");

                    Console.Write("Username: ");
                    var username = Console.ReadLine();

                    Console.Write("Password: ");
                    var password = Console.ReadLine();

                    Console.Write("Role(user/admin): ");
                    var role = Console.ReadLine();

                    if (role == "" || password == "" || username == "")
                    {
                        Console.Clear();
                        Console.WriteLine("Fields cannot be blank");

                        Thread.Sleep(2000);

                    }

                    else if (role == "admin" || role == "user")
                    {
                        var newUser = new User(username, password, role);

                        db.Users.Add(newUser);

                        db.SaveChanges();

                        Console.Clear();

                        Console.WriteLine($"User {username} was successfully added.");

                        Thread.Sleep(2000);

                        runningAddMenu = false;

                        Console.Clear();
                    }

                    else
                    {
                        Console.Clear();

                        Console.WriteLine("Invalid role");

                        Thread.Sleep(2000);
                    }
                } while (runningAddMenu);
            }
        }
    }
}