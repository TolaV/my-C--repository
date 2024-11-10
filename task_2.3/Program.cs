using System;
using ConsoleApp3;

namespace HM02
{
    class Program
    {
        static void Main(string[] args)
        {
            var training = new Training();

            training.Add(new Lecture("Introduction to C#", "Basics of C#"));
            training.Add(new PracticalLesson("Hands-on C# Basics", "Solve basic problems", "solution1"));
            training.Add(new PracticalLesson("Hands-on Advanced C#", "Solve advanced problems", "solution2"));

            Console.WriteLine("Original Training");
            training.Display();

            var clonedTraining = training.Clone();
            Console.WriteLine("\nCloned Training");
            clonedTraining.Display();

            training.Add(new Lecture("Advanced C#", "Deep Dive"));
            Console.WriteLine("\nIs the original training practical only? " + training.IsPractical());
        }
    }
}