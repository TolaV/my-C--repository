using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class DiagonalMatrix
    {
        private int[] diagonalElements;
        public int Size { get; set; }
        public int[] DiagonalElements => (int[])diagonalElements.Clone();

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
        private bool CheckIndex(int i, int j)
        {
            return i >= 0 && j >= 0 && i < Size && j < Size && i == j;
        }

        public int this[int i, int j]
        {
            get
            {
                if (!CheckIndex(i, j))
                    return 0;
                return diagonalElements[i];
            }
            set
            {
                if (!CheckIndex(i, j))
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
}

