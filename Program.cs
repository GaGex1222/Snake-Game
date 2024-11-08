using System;
using System.Collections.Generic;

namespace SnakeConsle
{
    public class Program
    {
        public static void Main()
        {
            Coordinates gridDimensions = new Coordinates(15, 50);
            Coordinates snakePos = new Coordinates(10, 10);
            Random random = new Random();
            Coordinates apple = new Coordinates(random.Next(1, gridDimensions.X - 1), random.Next(1, gridDimensions.Y - 1));
            List<Coordinates> bodies = new List<Coordinates> { snakePos };
            int score = 0; 
            int delay = 100;

            while (true)
            {
                Console.Clear();
                for (int x = 0; x < gridDimensions.X; x++)
                {
                    for (int y = 0; y < gridDimensions.Y; y++)
                    {
                        Coordinates currectCoordinate = new Coordinates(x, y);
                        if (bodies[0].Equals(currectCoordinate))
                            Console.Write("■");
                        else if (bodies.Contains(currectCoordinate))
                            Console.Write("■");
                        else if (apple.Equals(currectCoordinate))
                            Console.Write("a");
                        else if (x == gridDimensions.X - 1 || y == gridDimensions.Y - 1 || x == 0 || y == 0)
                            Console.Write("#");
                        else
                            Console.Write(" ");
                    }
                    Console.WriteLine(); // Move to the next line after completing the inner loop
                }
                Console.WriteLine("Score: " + score);
                Directions.ChangeMovement();
                for (int i = bodies.Count - 1; i > 0; i--)
                {
                    bodies[i] = new Coordinates(bodies[i - 1].X, bodies[i - 1].Y);
                }
                bodies[0] = Directions.ApplyMovement(bodies[0]);
                Coordinates snakeHead = bodies[0];
                if (snakeHead.X + 1 >= gridDimensions.X || snakeHead.Y + 1 >= gridDimensions.Y || snakeHead.X - 1 < 0 || snakeHead.Y - 1 < 0)
                {
                    goto OutofBounds;
                }
                if (snakeHead.Equals(apple))
                {
                    score += 1;
                    bodies.Add(new Coordinates(bodies[bodies.Count - 1].X - 1, bodies[bodies.Count - 1].Y - 1));
                    apple = new Coordinates(random.Next(1, gridDimensions.X - 1), random.Next(1, gridDimensions.Y - 1));
                }
                for(int i = 1; i < bodies.Count; i++)
                {
                    if (bodies[i].Equals(bodies[0]))
                    {
                        goto HitItself;
                    }
                }
                Thread.Sleep(delay);

            }
            OutofBounds:
                Console.WriteLine("Game Over! Snake out of bounds!");
            HitItself:
                Console.WriteLine("Game Over! Snake hit itself!");
        }
    }
}
