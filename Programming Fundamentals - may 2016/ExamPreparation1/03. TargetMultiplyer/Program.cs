using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.TargetMultiplyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            long[,] matrix = new long[rows,cols];

            for (int i = 0; i < rows; i++)
            {
                long[] row = Console.ReadLine().Split().Select(long.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            //0 1 2
            //1 1 2 
            //2 3 4
            int[] targetedCell = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int targetedCellX = targetedCell[0];
            int targetedCellY = targetedCell[1];

            long targetedCellValue = matrix[targetedCellX, targetedCellY];

           // long sumToMultiplyWith = matrix[targetedCellX - 1, targetedCellY - 1] +
           //                          matrix[targetedCellX, targetedCellY - 1] +
           //                          matrix[targetedCellX + 1, targetedCellY - 1] +
           //                          matrix[targetedCellX - 1, targetedCellY] +
           //                          matrix[targetedCellX + 1, targetedCellY] +
           //                          matrix[targetedCellX - 1, targetedCellY + 1] +
           //                          matrix[targetedCellX, targetedCellY + 1] +
           //                          matrix[targetedCellX + 1, targetedCellY + 1];

            long sumToMultiplyWith = 0;

            matrix[targetedCellX, targetedCellY] = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    try
                    {
                        sumToMultiplyWith += matrix[targetedCellX + j, targetedCellY + i];
                        matrix[targetedCellX + j, targetedCellY + i] *= targetedCellValue;
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                }
            }

            matrix[targetedCellX, targetedCellY] = targetedCellValue*sumToMultiplyWith;

            PrintMatrix(matrix);
        }

        public static void PrintMatrix(long[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
