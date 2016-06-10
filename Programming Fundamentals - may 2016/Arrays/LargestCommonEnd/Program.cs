using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestCommonEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(' ').ToArray();
            string[] arr2 = Console.ReadLine().Split(' ').ToArray();

            int shorter = Math.Min(arr1.Length, arr2.Length);
            int startIndex = 0;
            int length = 0;
            int largest = 0;

            for (int i = 0; i < shorter; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    startIndex = i;
                    length++;
                }
                else
                {
                    if (length > largest)
                    {
                        largest = length;
                    }
                    length = 0;
                }
            }

            int start = Math.Max(arr1.Length, arr2.Length) - 1;
            int end = start - shorter;
            int rightLength = 0;

            for (int i = start; i >= end; i--)
            {
                if (arr1[i] == arr2[i])
                {
                    startIndex = i;
                    rightLength++;
                }
                else
                {
                    if (rightLength > largest)
                    {
                        largest = rightLength;
                    }
                    rightLength = 0;
                }
            }

            Console.WriteLine(largest);
        }
    }
}
