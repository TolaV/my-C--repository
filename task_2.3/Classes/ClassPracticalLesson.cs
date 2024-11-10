using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class PracticalLesson : LessonItem
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
}
