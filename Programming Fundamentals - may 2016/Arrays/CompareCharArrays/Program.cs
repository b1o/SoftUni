using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareCharArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] arr1 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] arr2 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            bool equal = true;

            for (int i = 0; i < Math.Min(arr1.Length, arr2.Length); i++)
            {
                if (arr1[i].CompareTo(arr2[i]) < 0)
                {
                    Console.WriteLine($"{string.Join("", arr1)}\r\n{string.Join("", arr2)}");
                    equal = false;
                    break;
                }
                else if (arr1[i].CompareTo(arr2[i]) > 0)
                {
                    Console.WriteLine($"{string.Join("", arr2)}\r\n{string.Join("", arr1)}");
                    equal = false;
                    break;
                }
                else
                {
                    continue;
                }
            }

            if (equal)
            {
                if (arr1.Length < arr2.Length)
                {
                    Console.WriteLine($"{string.Join("", arr1)}\r\n{string.Join("", arr2)}");
                }
                else
                {
                    Console.WriteLine($"{string.Join("", arr2)}\r\n{string.Join("", arr1)}");
                }
            }
            else if (equal && arr1.Length == arr2.Length)
            {
                Console.WriteLine($"{string.Join("", arr1)}\r\n{string.Join("", arr2)}");
            }
        }
    }
}
