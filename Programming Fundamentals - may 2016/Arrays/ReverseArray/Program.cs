using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            var length = input.Length;

            for (int i = 0; i < (input.Length / 2); i++)
            {
                var temp = input[i];
                input[i] = input[length - i - 1];
                input[length - i - 1] = temp;
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
