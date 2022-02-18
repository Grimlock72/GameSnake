using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    public class Board
    {
        public readonly int Height;
        public readonly int Width;
        public bool ContainsCaramel;

        public Board(int height, int width)
        {
            Height = height;
            Width = width;
            ContainsCaramel = false;
        }

        public void DrawBoard()
        {
            for (int i = 0; i <= Height; i++)
            {
                //// Right line
                //Console.SetCursorPosition(0, i);
                //Console.WriteLine("#");

                Useful.DrawPosition(Width, i, "#");
                Useful.DrawPosition(0, i, "#");
            }

            for (int i = 0; i <= Width; i++)
            {
                Useful.DrawPosition(i, 0, "#");
                Useful.DrawPosition(i, Height, "#");
            }
        }
    }
}
