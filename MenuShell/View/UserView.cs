using System;

namespace MenuShell.View
{
    internal class UserView
    {
        public void DrawMenu()
        {
            do
            {
                Console.WriteLine("Welcome to the user menu");
                Console.WriteLine();
                Console.WriteLine("1. Exit");
            } while (Console.ReadKey(true).Key != ConsoleKey.D1);
        }
    }
}