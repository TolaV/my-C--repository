using System;

namespace HM02
{
    public class DiagonalMatrix
    {
        private int[] diagonalElements;
        public int Size { get; set; }

        public DiagonalMatrix(params int[] diagonal)
        {
            if (diagonal == null)
            {
                diagonalElements = new int[0];
                Size = 0;
            }
            else
            {
                diagonalElements = new int[diagonal.Length];
                diagonal.CopyTo(diagonalElements, 0);
                Size = diagonal.Length;
            }
        }

        public int this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i >= Size || j >= Size || i != j)
                    return 0;
                return diagonalElements[i];
            }
            set
            {
                if (i >= 0 && j >= 0 && i < Size && j < Size && i == j)
                    diagonalElements[i] = value;
            }
        }

        public int Trace()
        {
            int sum = 0;
            for (int i = 0; i < Size; i++)
            {
                sum += diagonalElements[i];
            }
            return sum;
        }

        public override bool Equals(object obj)
        {
            if (obj is DiagonalMatrix otherMatrix)
            {
                if (this.Size != otherMatrix.Size)
                    return false;

                for (int i = 0; i < Size; i++)
                {
                    if (this.diagonalElements[i] != otherMatrix.diagonalElements[i])
                        return false;
                }
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string matrixString = "[";
            for (int i = 0; i < Size; i++)
            {
                matrixString += diagonalElements[i] + " ";
            }
            matrixString += "]";
            return matrixString;
        }

        public static DiagonalMatrix Add(DiagonalMatrix matrix1, DiagonalMatrix matrix2)
        {
            int maxSize = Math.Max(matrix1.Size, matrix2.Size);
            int[] resultDiagonal = new int[maxSize];

            for (int i = 0; i < maxSize; i++)
            {
                int element1 = (i < matrix1.Size) ? matrix1.diagonalElements[i] : 0;
                int element2 = (i < matrix2.Size) ? matrix2.diagonalElements[i] : 0;
                resultDiagonal[i] = element1 + element2;
            }

            return new DiagonalMatrix(resultDiagonal);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DiagonalMatrix matrix1 = new DiagonalMatrix(1, 2, 3);
            DiagonalMatrix matrix2 = new DiagonalMatrix(4, 5);

            Console.WriteLine(matrix1[0, 0]);
            Console.WriteLine(matrix1[2, 2]);

            DiagonalMatrix sumMatrix = DiagonalMatrix.Add(matrix1, matrix2);
            Console.WriteLine(sumMatrix);

            Console.WriteLine(matrix1.Trace());
            Console.WriteLine(matrix1.Equals(new DiagonalMatrix(1, 2, 3)));
        }
    }
}
