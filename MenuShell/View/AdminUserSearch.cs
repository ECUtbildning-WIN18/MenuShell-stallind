using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using MenuShell.Domain;
using System.Threading;

namespace MenuShell.View
{
    class AdminUserSearch
    {
        public static bool RunningFindUser = true;

        public static string UserSearch = "";

        public void FindUser()
        {
            do
            {
                RunningFindUser = true;

                Console.Clear();

                Console.Write("Enter search string:");

                UserSearch = Console.ReadLine(); 

                var databaseSQL = new DataBase();
                
                List<User> foundUsers = databaseSQL.UserSearch(UserSearch);

                if (UserSearch != string.Empty)
                {
                    List<User> searchList = foundUsers.FindAll(user => user.Username.ToLower().Contains(UserSearch.ToLower()));

                    PrintSearchList(searchList);
                }
                else
                {
                    Console.Clear();

                    Console.WriteLine("Invalid search string");

                    Thread.Sleep(1000);
                }
                
            } while (RunningFindUser);
        }

        public void PrintSearchList(List<User> searchList)
        {
            if (searchList.Count == 0)
            {
                Console.WriteLine("No matches found.");
            }
            else
            {
                foreach (var search in searchList)
                {
                        Console.WriteLine($"Found the following users starting with or containing '{UserSearch}'");

                        Console.WriteLine($"* {search.Username}");
                }
            }

            Console.WriteLine("\n\n\n");

            Console.WriteLine("Press any key to perform a new search or press b to return to admin menu.");

            if (ConsoleKey.B == Console.ReadKey(true).Key)
            {
                RunningFindUser = false;
            }
        }

    }
}
