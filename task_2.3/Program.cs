using System;

namespace HM02
{
    public class Lecture
    {
        public string Description { get; set; }
        public string Topic { get; set; }
        public string LinkToTheTask { get; set; }
        public string LinkToTheSolution { get; set; }

        public Lecture()
        {
            Description = string.Empty;
            Topic = string.Empty;
        }
        public Lecture(string description, string topic)
        {
            Description = description;
            Topic = topic;
        }
        public Lecture Clone()
        {
            return new Lecture(this.Description, this.Topic);
        }
    }
    public class PracticalLesson
    {
        public string Description { get; set; }
        public string LinkToTheTask { get; set; }
        public string LinkToTheSolution { get; set; }

        public PracticalLesson()
        {
            Description = string.Empty;
            LinkToTheTask = string.Empty;
            LinkToTheSolution = string.Empty;
        }
        public PracticalLesson(string description, string linkToTheTask, string linkToTheSolution)
        {
            Description = description;
            LinkToTheTask = linkToTheTask;
            LinkToTheSolution = linkToTheSolution;
        }
        public PracticalLesson Clone()
        {
            return new PracticalLesson(this.Description, this.LinkToTheTask, this.LinkToTheSolution);
        }
    }
    class Training
    {
        private List<object> items = new List<object>();

        public void Add(object item)
        {
            items.Add(item);
        }
        public bool IsPractical()
        {
            foreach (var item in items)
            {
                if (!(item is PracticalLesson))
                {
                    return false;
                }
            }
            return true;
        }
        public Training Clone()
        {
            var clonedTraining = new Training();
            foreach (var item in items)
            {
                if (item is Lecture lecture)
                {
                    clonedTraining.Add(lecture.Clone());
                }
                else if (item is PracticalLesson practicalLesson)
                {
                    clonedTraining.Add(practicalLesson.Clone());
                }
            }
            return clonedTraining;
        }
        public void Display()
        {
            foreach (var item in items)
            {
                if (item is Lecture lecture)
                {
                    Console.WriteLine($"Lecture: {lecture.Description}, topic: {lecture.Topic}");
                }
                if (item is PracticalLesson practical)
                {
                    Console.WriteLine($"Practical: {practical.Description}, link to the task: {practical.LinkToTheTask}, link to the solution: {practical.LinkToTheSolution}");
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var training = new Training();

            training.Add(new Lecture("Introduction to C#", "Basics of C#"));
            training.Add(new PracticalLesson("Hands-on C# Basics", "Solve basic problems", "solution1"));
            training.Add(new PracticalLesson("Hands-on Advanced C#", "Solve advanced problems", "solution2"));

            Console.WriteLine("Original Training:");
            training.Display();

            var clonedTraining = training.Clone();

            Console.WriteLine("\nCloned Training:");
            clonedTraining.Display();

            training.Add(new Lecture("Advanced C#", "Deep Dive"));
            Console.WriteLine("\nIs the original training practical only? " + training.IsPractical());

        }
    }
}