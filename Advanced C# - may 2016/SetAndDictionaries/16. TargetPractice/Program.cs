using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimesnions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimesnions[0];
            int cols = dimesnions[1];
            char[,] matrix = new char[rows,cols];

            string snake = Console.ReadLine();
            int snakeCharCounter = 0;

            for (int i = rows - 1; i >= 0; i--)
            {
                for (int j = cols - 1; j >= 0; j--)
                {
                    matrix[i, j] = snake[snakeCharCounter];
                    snakeCharCounter++;
                    if (snakeCharCounter > snake.Length - 1)
                    {
                        snakeCharCounter = 0;
                    }
                }
            }

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
