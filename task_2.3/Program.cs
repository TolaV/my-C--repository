using System;

namespace HM02
{
    public abstract class LessonItem
    {
        public string Description { get; set; }

        protected LessonItem(string description)
        {
            Description = description ?? string.Empty;
        }

        public abstract LessonItem Clone();
    }

    public class Lecture : LessonItem
    {
        public string Topic { get; set; }

        public Lecture(string description, string topic) : base(description)
        {
            Topic = topic ?? string.Empty;
        }

        public override LessonItem Clone()
        {
            return new Lecture(this.Description, this.Topic);
        }
    }

    public class PracticalLesson : LessonItem
    {
        public string LinkToTheTask { get; set; }
        public string LinkToTheSolution { get; set; }

        public PracticalLesson(string description, string linkToTheTask, string linkToTheSolution) : base(description)
        {
            LinkToTheTask = linkToTheTask ?? string.Empty;
            LinkToTheSolution = linkToTheSolution ?? string.Empty;
        }

        public override LessonItem Clone()
        {
            return new PracticalLesson(this.Description, this.LinkToTheTask, this.LinkToTheSolution);
        }
    }

    public class Training
    {
        private LessonItem[] items;
        private int count;

        public Training()
        {
            items = new LessonItem[4]; 
            count = 0;
        }

        public void Add(LessonItem item)
        {
            if (count >= items.Length)
            {
                Resize();
            }
            items[count] = item;
            count++;
        }

        private void Resize()
        {
            int newSize = items.Length * 2; 
            LessonItem[] newArray = new LessonItem[newSize]; 
            Array.Copy(items, newArray, items.Length); 
            items = newArray; 
        }

        public bool IsPractical()
        {
            for (int i = 0; i < count; i++)
            {
                if (!(items[i] is PracticalLesson)) 
                {
                    return false;
                }
            }
            return true;
        }

        public Training Clone()
        {
            var clonedTraining = new Training();
            for (int i = 0; i < count; i++)
            {
                clonedTraining.Add(items[i].Clone()); 
            }
            return clonedTraining;
        }

        public void Display()
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i] is Lecture lecture)
                {
                    Console.WriteLine($"Lecture: {lecture.Description}, topic: {lecture.Topic}");
                }
                else if (items[i] is PracticalLesson practical)
                {
                    Console.WriteLine($"Practical: {practical.Description}, link to task: {practical.LinkToTheTask}, link to solution: {practical.LinkToTheSolution}");
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
