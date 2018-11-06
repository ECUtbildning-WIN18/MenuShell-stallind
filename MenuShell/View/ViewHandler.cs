using System;

namespace MenuShell.View
{
    internal class ViewHandler
    {
        public static void MainMenu()
        {
            var isRunning = true;

            var loginView = new LoginView();

            do
            {
                Console.Clear();
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Exit");

                var menuChoice = Console.ReadKey(true).Key;

                switch (menuChoice)
                {
                    case ConsoleKey.D1:

                        Console.Clear();

                        loginView.Login();

                        break;

                    case ConsoleKey.D2:

                        ConfirmExitView.ConfirmExit();

                        break;
                }
            } while (isRunning);
        }
    }
}