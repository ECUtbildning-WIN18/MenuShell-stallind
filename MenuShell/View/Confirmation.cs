using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace MenuShell.View
{
    class Confirmation : ViewHandler
    {
        public void Confirm()
        {
            var loop = true;

            do
            {
                Console.WriteLine("Are you sure?\n (Y)es, (N)o");

                var selection = Console.ReadKey(true).Key;

                switch (selection)
                {

                    case ConsoleKey.Y:
                        Environment.Exit(0);
                        break;

                    case ConsoleKey.N:
                        Console.Clear();
                        var back = new ViewHandler();
                        Console.Clear();
                        Console.WriteLine("Returning to start menu.");
                        Thread.Sleep(3000);
                        back.MainMenu();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid selection, try again.");
                        Thread.Sleep(500);
                        Console.Clear();
                        break;
                }

            } while (loop);


        }
    }
} 


