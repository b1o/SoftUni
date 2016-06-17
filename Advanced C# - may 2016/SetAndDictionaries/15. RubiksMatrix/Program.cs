using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.RubiksMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int r = dimensions[0];
            int c = dimensions[1];

            int[,] matrix = new int[r,c];

            int numberToFill = 1;

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    matrix[i, j] = numberToFill;
                    numberToFill++;
                }
            }

            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                int position = int.Parse(tokens[0]);
                string direction = tokens[1];
                int times = int.Parse(tokens[2]);

                switch (direction)
                {
                    case "up":
                    case "down":
                        ShuffleCol(matrix, direction, times, position);
                        break;
                    case "left":
                    case "right":
                        ShuffleRow(matrix, direction, times, position);
                        break;
                }
            }

            RearangeMatrix(matrix);
        }

        public static void RearangeMatrix(int[,] matrix)
        {
            int counter = 1;
            bool isFirstTime = true;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int currentNumber = matrix[i, j];
                    if (currentNumber != counter)
                    {
                        for (int k = i; k < matrix.GetLength(0); k++)
                        {
                            bool end = false;
                            if (isFirstTime)
                            {
                                for (int l = j + 1; l < matrix.GetLength(1); l++)
                                {
                                    int searchedNumber = matrix[k, l];
                                    if (searchedNumber == counter)
                                    {
                                        matrix[i, j] = searchedNumber;
                                        matrix[k, l] = currentNumber;
                                        Console.WriteLine($"Swap ({i}, {j}) with ({k}, {l})");
                                        end = true;
                                        break;
                                    }
                                }
                                isFirstTime = false;
                            }
                            else
                            {
                                for (int l = 0; l < matrix.GetLength(1); l++)
                                {
                                    int searchedNumber = matrix[k, l];
                                    if (searchedNumber == counter)
                                    {
                                        matrix[i, j] = searchedNumber;
                                        matrix[k, l] = currentNumber;
                                        Console.WriteLine($"Swap ({i}, {j}) with ({k}, {l})");
                                        end = true;
                                        isFirstTime = true;
                                        break;
                                    }
                                }
                            }
                            if (end)
                            {
                                isFirstTime = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }
                    counter++;
                }
            }
        }

        public static void ShuffleCol(int[,] matrix, string direciton, int times, int col)
        {
            for (int j = 0; j < times; j++)
            {
                if (direciton == "up")
                {
                    int firstNumber = matrix[0, col];
                    for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                    {
                        matrix[i, col] = matrix[i + 1, col];
                    }
                    matrix[matrix.GetLength(0) - 1, col] = firstNumber;
                }
                else
                {
                    int lastNumber = matrix[matrix.GetLength(0) - 1, col];
                    for (int i = matrix.GetLength(0) - 1; i > 0; i--)
                    {
                        matrix[i, col] = matrix[i - 1, col];
                    }
                    matrix[0, col] = lastNumber;
                }
            }
        }

        public static void ShuffleRow(int[,] matrix, string direciton, int times, int row)
        {
            for (int i = 0; i < times; i++)
            {
                if (direciton == "left")
                {
                    int firstNumber = matrix[row, 0];
                    for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                    {
                        matrix[row, j] = matrix[row, j + 1];
                    }
                    matrix[row, matrix.GetLength(1) - 1] = firstNumber;
                }
                else
                {
                    int lastNumber = matrix[row, matrix.GetLength(1) - 1];
                    for (int j = matrix.GetLength(1) - 1; j > 0; j--)
                    {
                        matrix[row, j] = matrix[row, j - 1];
                    }
                    matrix[row, 0] = lastNumber;
                }
            }
        }

        public static void PrintMatrix(int[,] matrix)
        {
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
