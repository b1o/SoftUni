using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilledSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintHeaderRow(number);
            for (int i = 0; i < number - 2; i++)
            {
                PrintMiddleROw(number);
            }
            PrintHeaderRow(number);
        }

        static void PrintHeaderRow(int n)
        {
            for (int i = 0; i < n*2; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();
        }

        static void PrintMiddleROw(int n)
        {
            Console.Write('-');
            for (int i = 0; i < n-1; i++)
            {
                Console.Write("\\/");   
            }
            Console.Write('-');
            Console.WriteLine();
        }
    }
}
