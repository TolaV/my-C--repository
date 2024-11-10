using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Training
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
}
