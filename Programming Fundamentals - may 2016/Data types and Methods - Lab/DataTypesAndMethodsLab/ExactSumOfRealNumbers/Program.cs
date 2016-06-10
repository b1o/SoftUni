using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExactSumOfRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            decimal result = 0;

            for (int i = 0; i < count; i++)
            {
                decimal number = decimal.Parse(Console.ReadLine());
                result += number;
            }

            Console.WriteLine(result);
        }
    }
}
