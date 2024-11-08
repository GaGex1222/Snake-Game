using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeConsle
{
    public class Coordinates
    {
        private int y;
        private int x;
        public int X { get { return x; } }
        public int Y { get { return y; } }

        public Coordinates(int x, int y)
        {
            this.y = y;
            this.x = x;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Coordinates other = (Coordinates)obj;
            return x == other.x && y == other.y;
        }
    }
}
