using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the first number 'A': ");
        string s_a = Console.ReadLine();
        int a = int.Parse(s_a);

        Console.Write("Enter the second number 'B': ");
        string s_b = Console.ReadLine();
        int b = int.Parse(s_b);

        bool found = false;

        for (int i = a; i <= b; i++)
        {
            string duodecimal = ToDuodecimal(i);
            int countA = CountA(duodecimal);

            //Console.WriteLine($"Decimal: {i}, Duodecimal: {duodecimal}, Count of 'A': {countA}");

            if (countA == 2)
            {
                Console.WriteLine($"Found: {i} (Duodecimal: {duodecimal})");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No numbers found with exactly two 'A's in their duodecimal representation.");
        }
    }

    static string ToDuodecimal(int number)
    {
        if (number == 0) return "0";

        string result = "";
        while (number > 0)
        {
            int remainder = number % 12;
            if (remainder < 10)
                result = remainder + result;
            else if (remainder == 10)
                result = 'A' + result;
            else
                result = 'B' + result;
            number /= 12;
        }
        return result;
    }

    static int CountA(string s)
    {
        int count = 0;
        foreach (char c in s)
        {
            if (c == 'A')
            {
                count++;
            }
        }
        return count;
    }
}
