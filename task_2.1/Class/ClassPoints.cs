using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Points
    {
        private int[] coordinates = new int[3];
        private double mass;

        public int X
        {
            get { return coordinates[0]; }
            set { coordinates[0] = value; }
        }
        public int Y
        {
            get { return coordinates[1]; }
            set { coordinates[1] = value; }
        }
        public int Z
        {
            get { return coordinates[2]; }
            set { coordinates[2] = value; }
        }
        public double Mass
        {
            get { return mass; }
            set
            {
                if (value < 0)
                    mass = 0;
                else
                    mass = value;
            }
        }
        public Points(int x, int y, int z, double mass)
        {
            X = x;
            Y = y;
            Z = z;
            Mass = mass;
        }
        public bool IsZero()
        {
            return X == 0 && Y == 0 && Z == 0;
        }

        public double DistanceTo(Points otherPoint)
        {
            if (otherPoint == null)
            {
                throw new Exception("The other point cannot be null.");
            }
            int deltaX = otherPoint.X - this.X;
            int deltaY = otherPoint.Y - this.Y;
            int deltaZ = otherPoint.Z - this.Z;

            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
        }
    }
}
