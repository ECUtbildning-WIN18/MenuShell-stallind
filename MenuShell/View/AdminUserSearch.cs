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
        public static bool runningFindUser = true;

        public static string userSearch = "";

        public void FindUser(List<User> users)
        {
            do
            {
                Console.Clear();

                Console.Write("Enter search string:");

                userSearch = Console.ReadLine();

                if (userSearch != string.Empty)
                {
                    List<User> searchList = users.FindAll(user => user.UserName.ToLower().Contains(userSearch.ToLower()));

                    PrintSearchList(searchList);
                }
                else
                {
                    Console.WriteLine("Invalid search string");

                    Thread.Sleep(1000);
                }
                
            } while (runningFindUser);
        }

        public void PrintSearchList(List<User> searchList)
        {

            foreach (var search in searchList)
            {
                Console.WriteLine($"Found the following users starting with or containing {userSearch}");

                Console.WriteLine($"* {search.UserName}");
            }

            Console.WriteLine("\n\n\n");

            Console.WriteLine("Press any key to perform a new search or press b to return to admin menu.");

            if (ConsoleKey.B == Console.ReadKey(true).Key)
            {
                runningFindUser = false;
            }
        }

    }
}
