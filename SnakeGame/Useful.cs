using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    class Useful
    {
        public static void DrawPosition(int x, int y, string caracter)
        {
            // Left line
            Console.SetCursorPosition(x, y);
            Console.WriteLine(caracter);
        }
    }
}
