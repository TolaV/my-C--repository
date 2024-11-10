using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal static class MatrixExtensions
    {
        public static string ToString(this DiagonalMatrix matrix)
        {
            return "[" + string.Join(" ", matrix.DiagonalElements) + "]";
        }
    }
}
