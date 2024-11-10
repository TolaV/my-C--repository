using System;
using ConsoleApp1;

namespace HM02
{
    
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