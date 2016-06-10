using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastKNumbersSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            long[] seq = new long[n];
            seq[0] = 1;

            for (int i = 1; i < n; i++)
            {
                long sum = 0;
                for (int j = k; j > 0; j--)
                {
                    if (i - j < 0)
                    {
                        continue;
                    }
                    else
                    {
                        sum += seq[i - j];
                    }
                }
                seq[i] = sum;
            }

            for (int i = 0; i < seq.Length; i++)
            {
                Console.Write($"{seq[i]} ");
            }
        }
    }
}
