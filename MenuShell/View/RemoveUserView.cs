using System;
using System.Linq;
using System.Threading;
using MenuShell.Domain;

namespace MenuShell.View
{
    public class RemoveUserView
    {
        public static void RemoveUser()
        {
            using (var db = new MenuShellDbContext())
            {
                Console.Clear();

                Console.Write("Enter the username of which user to remove: ");

                var username = Console.ReadLine();

                var foundUser = db.Users.FirstOrDefault(x => x.Username == username);

                if (foundUser == null)
                {
                    Console.WriteLine($"No user named '{username}' found.");

                    Thread.Sleep(2000);
                    return;
                }

                db.Users.Remove(foundUser);

                db.SaveChanges();

                Console.WriteLine($"User {username} was successfully removed.");

                Thread.Sleep(2000);
            }
        }
    }
}