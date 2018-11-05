using System;
using System.Threading;

namespace MenuShell.View
{
    public class ConfirmExitView
    {
        public static void ConfirmExit()
        {
            var isRunning = true;

            do
            {
                Console.Clear();

                Console.WriteLine("Are you sure you want to exit the program?\n (Y)es, (N)o");

                var selection = Console.ReadKey(true).Key;

                switch (selection)
                {
                    case ConsoleKey.Y:

                        Console.Clear();
                        Console.WriteLine("Goodbye!");

                        Environment.Exit(0);
                        break;

                    case ConsoleKey.N:

                        Console.Clear();
                        isRunning = false;
                        break;

                    default:

                        Console.Clear();

                        Console.WriteLine("Invalid selection, try again.");

                        Thread.Sleep(500);

                        Console.Clear();

                        break;
                }
            } while (isRunning);
        }
    }
}