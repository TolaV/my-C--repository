using System;
using System.Collections;

namespace HM03
{
    public interface IQueue<T>
    {
        void Enqueue(T item);
        T Dequeue();
        bool IsEmpty();
        int Count { get; }
        void ShowDetails();

    }
    public class Queue<T>: IQueue<T>
    {
        private List<T> items = new List<T>();

        public Queue() { }
        public Queue( T item )
        {
            items.Add( item );
        }
        public List<T> Items => new List<T>(items);
        public void Enqueue(T item)
        {
            items.Add(item);
        }
        public T Dequeue()
        {
            if(IsEmpty())
            {
                throw new Exception("Queue is empty");
            }
            T item = items[0];
            items.RemoveAt(0);
            return item;
        }
        public bool IsEmpty()
        {
            if (items.Count == 0)
            {
                return true;
            }
            return false;
        }
        public int Count => items.Count;

        public void ShowDetails()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty.");
                return;
            }
            Console.WriteLine($"Amount of the elements: {Count}");
            Console.Write("Queue contents: ");
            foreach (var item in items)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
       
    }
    public static class QueueExtensions
    {
        public static Queue<T> Tail<T>(this IQueue<T> queue)
        {
            if (queue.IsEmpty())
            {
                throw new Exception("Queue is empty");
            }

            Queue<T> newQueue = new Queue<T>();

            for (int i = 0; i < queue.Count; i++)
            {
                newQueue.Enqueue(((Queue<T>)queue).Items[i]); 
            }

            newQueue.Dequeue(); 
            return newQueue;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IQueue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            //queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(5);
            queue.Enqueue(7);

            Console.WriteLine("Queue before Tail");
            ((Queue<int>)queue).ShowDetails();

            IQueue<int> tailQueue = queue.Tail();
            Console.WriteLine("\nQueue after Tail");
            ((Queue<int>)tailQueue).ShowDetails();
        }

        
    }
    
}