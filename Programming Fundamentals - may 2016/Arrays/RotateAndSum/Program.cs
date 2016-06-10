using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rotationsCount = int.Parse(Console.ReadLine());
            int[] sumArray = new int[input.Length];

            int[][] result = new int[rotationsCount][];

            for (int i = 0; i < rotationsCount; i++)
            {
                result[i] = Rotate(input);
                input = result[i];
            }

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                    sumArray[j] += result[i][j];
                }
            }

            Console.WriteLine(string.Join(" ", sumArray));
        }

        static int[] Rotate(int[] arr)
        {
            int[] rotated = new int[arr.Length];

            rotated[0] = arr.Last();
            var a = arr.Take(arr.Length - 1).ToArray();
            a.CopyTo(rotated, 1);

            return rotated;
        }
    }
}
