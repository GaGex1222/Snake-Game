using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeConsle
{
    public class Directions
    {
        static Coordinates left = new Coordinates(0, -1);
        static Coordinates right = new Coordinates(0, 1);
        static Coordinates up = new Coordinates(-1, 0);
        static Coordinates down = new Coordinates(1, 0);
        private static Coordinates currentDirection = right;
        public static Coordinates CurrentDirection
        {
            get { return currentDirection; }
            set { currentDirection = value; }
        }


        public static void ChangeMovement()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if(CurrentDirection != right)
                        {
                            CurrentDirection = left;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (CurrentDirection != left)
                        {
                            CurrentDirection = right;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if(currentDirection != down)
                        {
                            CurrentDirection = up;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if(currentDirection != up)
                        {
                            CurrentDirection = down;
                        }
                        break;
                }
            }
        }

        public static Coordinates ApplyMovement(Coordinates snakePos)
        {
            return new Coordinates(snakePos.X + currentDirection.X, currentDirection.Y + snakePos.Y);
        }
    }
}
