using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            var yes = 0;

            for (int a = 0; a < input.Length - 1; a++)
            {
                for (int b = a+1; b < input.Length; b++)
                {
                    var c = input[a] + input[b];
                    if (input.Contains(c))
                    {
                        Console.WriteLine($"{input[a]} + {input[b]} == {c}");
                        yes++;
                    }
                }
            }

            if (yes == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
