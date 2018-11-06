using System;
using System.Linq;
using MenuShell.Domain;

namespace MenuShell.View
{
    public class ListUserViev
    {
        public static void ListUser()
        {
            using (var db = new MenuShellDbContext())
            {
                Console.Clear();

                var userList = db.Users.ToList();

                Console.WriteLine("Listing users and their role.\n");

                foreach (var user in userList) Console.WriteLine($"{user.Username} {user.Role}");

                Console.WriteLine("\nPress any key to return to admin menu");

                Console.ReadKey();
            }
        }
    }
}