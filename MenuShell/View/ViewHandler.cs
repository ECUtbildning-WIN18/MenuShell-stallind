using System;
using MenuShell.View;

namespace MenuShell.View
{
    class ViewHandler
    {
        public void MainMenu()
        {
            var isRunning = true;

            var loginView = new LoginView();

            var confirm = new Confirmation();

            do
            {
                Console.Clear();
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Exit");

                ConsoleKey menuChoice = Console.ReadKey(true).Key;

                switch (menuChoice)
                {
                    case ConsoleKey.D1:

                        Console.Clear();

                        loginView.Login();

                        break;

                    case ConsoleKey.D2:

                        confirm.ConfirmExit();

                        break;
                }

            } while (isRunning);
        }
    }
}
