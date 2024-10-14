using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of elements in the array: ");
        int n = int.Parse(Console.ReadLine());

        int[] originalArray = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter element {i + 1}: ");
            originalArray[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Original Array: " + string.Join(", ", originalArray));

        int[] uniqueArray = CreateUniqueArray(originalArray, n);

        Console.WriteLine("Unique Array: " + string.Join(", ", uniqueArray));
    }

    static int[] CreateUniqueArray(int[] originalArray, int length)
    {
        int[] tempArray = new int[length];
        int uniqueCount = 0;

        for (int i = 0; i < length; i++)
        {
            bool exists = false;
            for (int j = 0; j < uniqueCount; j++)
            {
                if (originalArray[i] == tempArray[j])
                {
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                tempArray[uniqueCount] = originalArray[i];
                uniqueCount++;
            }
        }

        int[] finalUniqueArray = new int[uniqueCount];
        for (int i = 0; i < uniqueCount; i++)
        {
            finalUniqueArray[i] = tempArray[i];
        }

        return finalUniqueArray;
    }
}
