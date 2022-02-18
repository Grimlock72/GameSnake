using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    public class Caramel
    {
        public Position Position { get; set; }

        public Caramel(int x, int y)
        {
            Position = new Position(x, y);
        }

        public void DrawCaramel()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Useful.DrawPosition(Position.X, Position.Y, "O");
            Console.ResetColor();
        }

        public static Caramel CreateCaramel(Snake snake, Board board)
        {
            bool validCaramel = false;
            int x = 0;
            int y = 0;

            do
            {
                Random random = new Random();
                x = random.Next(1, board.Width - 1);
                y = random.Next(1, board.Height - 1);
                validCaramel = snake.QueuePosition(x, y);
            } while (validCaramel);

            board.ContainsCaramel = true;
            return new Caramel(x, y);
        }
    }
}
