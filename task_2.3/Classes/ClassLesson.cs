using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Lecture : LessonItem
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
}
