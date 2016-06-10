using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] firstRow = new int[(input.Length/4)*2];
            int[] secondRow = new int[firstRow.Length];
            int[] result = new int[input.Length/2];

            int[] a = input.Take(input.Length/4).Reverse().ToArray();
            int[] b = input.Skip(input.Length - a.Length).Reverse().ToArray();

            secondRow = input.Skip(a.Length).Take(firstRow.Length).ToArray();

            a.CopyTo(firstRow, 0);
            b.CopyTo(firstRow, b.Length);

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = firstRow[i] + secondRow[i];
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
