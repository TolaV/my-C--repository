using System;

namespace HM02
{
    public class Points
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
    class Program
    {
        static void Main(string[] args)
        {
            Points point1 = new Points(3, 4, 5, 10);
            Points point2 = new Points(0, 0, 0, 5);
            Points point3 = new Points(0, 0, 0, -2);

            Console.WriteLine("Point1: ");
            Console.WriteLine($"Coordinates: ({point1.X}, {point1.Y}, {point1.Z}), Mass: {point1.Mass}");

            Console.WriteLine("Point2: ");
            Console.WriteLine($"Coordinates: ({point2.X}, {point2.Y}, {point2.Z}), Mass: {point2.Mass}");
            
            Console.WriteLine("Point3: ");
            Console.WriteLine($"Coordinates: ({point3.X}, {point3.Y}, {point3.Z}), Mass: {point3.Mass}");

            Console.WriteLine("\nIs Point2 zero? " + point2.IsZero());
            Console.WriteLine("Is Point3 zero? " + point3.IsZero());

            double distance = point1.DistanceTo(point2);
            double distance1 = point2.DistanceTo(point3);
            Console.WriteLine($"\nDistance between Point1 and Point2: {distance}");
            Console.WriteLine($"Distance between Point2 and Point3: {distance1}");

            point1.Mass = -5;
            Console.WriteLine($"After setting a negative mass, Point1 Mass: {point1.Mass}");

        }
    }
}