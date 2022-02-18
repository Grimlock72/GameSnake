using System;
using System.Diagnostics;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(20, 20);

            Snake snake = new Snake(10, 10);
            Caramel caramel = new Caramel(0, 0);
            bool hasEaten = false;

            do
            {
                Console.Clear();
                board.DrawBoard();

                snake.CheckDie(board);
                if (snake.SheIsAlive)
                {
                    snake.Move(hasEaten);

                    // We check if the caramel has been eaten
                    hasEaten = snake.EatCaramel(caramel, board);

                    // We draw the snake
                    snake.DrawSnake();
                    if (!board.ContainsCaramel)
                    {
                        caramel = Caramel.CreateCaramel(snake, board);
                    }

                    // We draw the caramel
                    caramel.DrawCaramel();
                
                    // We read information by keyboard from the direction
                    var sw = Stopwatch.StartNew();
                    while (sw.ElapsedMilliseconds <= 250)
                    {
                        snake.Direction = ReadMovement(snake.Direction);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Useful.DrawPosition(board.Width / 2, board.Height / 2, "Game Over");
                    Useful.DrawPosition(board.Width / 2, (board.Height / 2) + 1, $"Punctuation {snake.Points}");
                    Console.ResetColor();
                }

                
            } while (snake.SheIsAlive);



            Console.ReadKey();
        }

        static Direction ReadMovement(Direction currentMovement)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow && currentMovement != Direction.Below)
                {
                    return Direction.Above;
                }
                else if (key == ConsoleKey.DownArrow && currentMovement != Direction.Above)
                {
                    return Direction.Below;
                }
                else if (key == ConsoleKey.LeftArrow && currentMovement != Direction.Right)
                {
                    return Direction.Left;
                }
                else if (key == ConsoleKey.RightArrow && currentMovement != Direction.Left)
                {
                    return Direction.Right;
                }
            }
            return currentMovement;
        }
    }
}
