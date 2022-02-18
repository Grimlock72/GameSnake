using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame
{
    public class Snake
    {
        List<Position> Queue { get; set; }
        public Direction Direction { get; set; }
        public int Points { get; set; }
        public bool SheIsAlive { get; set; }

        public Snake(int x, int y)
        {
            Position initialPosition = new Position(x, y);
            Queue = new List<Position>() { initialPosition };
            Direction = Direction.Below;
            Points = 0;

            SheIsAlive = true;
        }

        public void DrawSnake()
        {
            foreach (Position position in Queue)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Useful.DrawPosition(position.X, position.Y, "x");
                Console.ResetColor();
            }
        }

        public void CheckDie(Board board)
        {
            // If we crash into us
            Position firstPosition = Queue.First();

            SheIsAlive = !((Queue.Count(a => a.X == firstPosition.X && a.Y == firstPosition.Y) > 1)
                || HeadIsOnTheWall(board, Queue.First()));
        }

        //public bool CalculateQueueShock(Position firstPosition)
        //{
            
        //}

        // If the first position is in any of the walls, we die
        private bool HeadIsOnTheWall(Board board, Position firstPosition)
        {
            return firstPosition.Y == 0 || firstPosition.Y == board.Height
                || firstPosition.X == 0 || firstPosition.X == board.Width;
        }

        public void Move(bool hasEaten)
        {
            List<Position> newQueue = new List<Position>();
            newQueue.Add(GetNewFirstPosition());
            newQueue.AddRange(Queue);

            if (!hasEaten)
            {
                newQueue.Remove(newQueue.Last());
            }

            Queue = newQueue;
        }

        private Position GetNewFirstPosition()
        {
            int x = Queue.First().X;
            int y = Queue.First().Y;

            switch (Direction)
            {
                case Direction.Below:
                    y += 1;
                    break;
                case Direction.Above:
                    y -= 1;
                    break;
                case Direction.Right:
                    x += 1;
                    break;
                case Direction.Left:
                    x -= 1;
                    break;
            }
            return new Position(x, y);
        }

        public bool QueuePosition(int x, int y)
        {
            return Queue.Any(a => a.X == x && a.Y == y);
        }

        public bool EatCaramel(Caramel caramel, Board board)
        {
            // Increase size
            // Increase speed
            // Remove caramel

            if (QueuePosition(caramel.Position.X, caramel.Position.Y))
            {
                Points += 10; // Score points
                board.ContainsCaramel = false; // Remove caramel or generate a new one
                return true;
            }
            return false;
        }

        public void AddItemToQueue(int x, int y)
        {

        }
    }
}
