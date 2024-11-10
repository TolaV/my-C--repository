using System;
using ConsoleApp2;

namespace HM02
{
    class Program
    {
        static void Main(string[] args)
        {
            DiagonalMatrix matrix1 = new DiagonalMatrix(1, 2, 3);
            DiagonalMatrix matrix2 = new DiagonalMatrix(4, 5);
            Console.WriteLine($"M1 : {MatrixExtensions.ToString(matrix1)}");
            Console.WriteLine($"M2: {MatrixExtensions.ToString(matrix2)}");

            Console.WriteLine($"m1 (0, 0): {matrix1[0, 0]}"); 
            Console.WriteLine($"m2 (2, 2): {matrix1[2, 2]}");

            DiagonalMatrix sumMatrix = DiagonalMatrix.Add(matrix1, matrix2);
            Console.WriteLine($"Sum: {MatrixExtensions.ToString(sumMatrix)}"); 

            Console.WriteLine($"Trace: {matrix1.Trace()}"); 
            Console.WriteLine($"Equals: {matrix1.Equals(new DiagonalMatrix(1, 2, 3))}"); 
        }
    }
}
