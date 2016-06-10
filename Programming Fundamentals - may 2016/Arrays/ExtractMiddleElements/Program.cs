using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractMiddleElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            if (input.Length == 1)
            {
                Console.WriteLine(input.First());
            }
            else if (input.Length%2 == 0)
            {
                Console.WriteLine($"{input[(input.Length/2) - 1]}, {input[input.Length/2]}");
            }
            else
            {
                Console.WriteLine($"{input[(input.Length / 2) - 1]}, {input[input.Length / 2]}, {input[(input.Length / 2) + 1]}");
            }
        }
    }
}
