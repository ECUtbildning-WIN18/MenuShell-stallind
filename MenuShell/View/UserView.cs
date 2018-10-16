using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MenuShell.View
{
    class UserView
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
