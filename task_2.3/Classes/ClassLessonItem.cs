using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal abstract class LessonItem
    {
        public string Description { get; set; }

        protected LessonItem(string description)
        {
            Description = description ?? string.Empty;
        }

        public abstract LessonItem Clone();
    }
}
