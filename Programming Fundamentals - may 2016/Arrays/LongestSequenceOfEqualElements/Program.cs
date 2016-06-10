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
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int start = 0;
            int length = 1;
            int bestStart = start;
            int bestLength = length;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == input[i - 1])
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
             
            int[] seq = new int[bestLength];
            Array.Copy(input, bestStart, seq, 0, bestLength);
            Console.WriteLine($"{string.Join(" ", seq)}");
        }
    }
}
