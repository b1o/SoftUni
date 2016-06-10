using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] input = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            long start = 0;
            long length = 1;
            long bestStart = start;
            long bestLength = length;

            for (long i = 1; i < input.Length; i++)
            {
                if (input[i] - 1 == input[i - 1])
                {
                    length++;
                }
                else
                {
                    start = i;
                    length = 1;
                }

                if (length > bestLength)
                {
                    bestLength = length;
                    bestStart = start;
                }
            }

            long[] seq = new long[bestLength];
            Array.Copy(input, bestStart, seq, 0, bestLength);
            Console.WriteLine($"{string.Join(" ", seq)}");
        }
    }
}
