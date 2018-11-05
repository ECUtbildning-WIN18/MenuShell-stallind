using System;
using System.Collections.Generic;
using MenuShell.Domain;

namespace MenuShell.View
{
    public class AdminView
    {
        public static bool runningDrawMenu = true;

        public void DrawMenu(List<User> users)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Admin menu\n");
                Console.WriteLine("1. Add user.");
                Console.WriteLine("2. Remove user.");
                Console.WriteLine("3. List all users.");
                Console.WriteLine("4. Search user.");
                Console.WriteLine("5. Exit.");

                var menuChoice = Console.ReadKey(true).Key;

                switch (menuChoice)
                {
                    case ConsoleKey.D1:

                        AddUserView.AddUser();
                        break;

                    case ConsoleKey.D2:

                        RemoveUserView.RemoveUser();
                        break;

                    case ConsoleKey.D3:

                        ListUserViev.ListUser();
                        break;

                    case ConsoleKey.D4:

                        UserSearchView.FindUser();
                        break;

                    case ConsoleKey.D5:

                        ConfirmExitView.ConfirmExit();
                        break;

                    default:
                        Console.Clear();
                        break;
                }
            } while (runningDrawMenu);
        }
    }
}