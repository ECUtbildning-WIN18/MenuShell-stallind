using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MenuShell.Domain;

namespace MenuShell.View
{
    internal class UserSearchView
    {
        public static bool RunningFindUser = true;

        public static string UserSearch = "";

        public static void FindUser()
        {
            do
            {
                using (var db = new MenuShellDbContext())
                {
                    RunningFindUser = true;

                    Console.Clear();

                    Console.Write("Enter search string:");

                    UserSearch = Console.ReadLine();

                    var foundUsers = db.Users.ToList();

                    if (UserSearch != string.Empty)
                    {
                        var searchList =
                            foundUsers.FindAll(user => user.Username.ToLower().Contains(UserSearch.ToLower()));

                        PrintSearchList(searchList);
                    }
                    else
                    {
                        Console.Clear();

                        Console.WriteLine("Invalid search string");

                        Thread.Sleep(1000);
                    }
                }
            } while (RunningFindUser);
        }

        public static void PrintSearchList(List<User> searchList)
        {
            if (searchList.Count == 0)
            {
                Console.Clear();

                Console.WriteLine("No matches found.");

                Console.WriteLine("\n\n\n");

                Console.WriteLine("Press any key to perform a new search or press b to return to admin menu.");

                if (ConsoleKey.B == Console.ReadKey(true).Key) RunningFindUser = false;
            }

            else
            {
                Console.WriteLine($"Found the following users starting with or containing '{UserSearch}'");

                foreach (var search in searchList) Console.WriteLine($"* {search.Username}");

                Console.WriteLine("\n\n\n");

                Console.WriteLine("Press any key to perform a new search or press b to return to admin menu.");

                if (ConsoleKey.B == Console.ReadKey(true).Key) RunningFindUser = false;
            }
        }
    }
}