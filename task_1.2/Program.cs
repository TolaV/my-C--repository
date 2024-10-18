using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the first 9 digits of the ISBN: ");
        string input = Console.ReadLine();

        int checkDigit = CalculateCheckDigit(input);

        string isbn = input;
        if (checkDigit == 10)
        {
            isbn += "X";
        }
        else
        {
            isbn += checkDigit.ToString();
        }

        Console.WriteLine("The complete ISBN is: " + isbn);
    }

    static int CalculateCheckDigit(string digits)
    {
        int sum = 0;

        for (int i = 0; i < digits.Length; i++)
        {
            int digit = int.Parse(digits[i].ToString());
            int weight = 10 - i;
            sum += digit * weight;
        }

        int remainder = sum % 11;
        int checkDigit;
        if (remainder == 0)
        {
            checkDigit = 0;
        }
        else
        {
            checkDigit = 11 - remainder;
        }
        return checkDigit;
    }
}
