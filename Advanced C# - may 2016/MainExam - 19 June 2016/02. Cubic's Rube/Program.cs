using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Cubic_s_Rube
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,,] rube = new int[n,n,n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        rube[i, j, k] = 0;
                    }
                }
            }

            string input = Console.ReadLine();
            while (input != "Analyze")
            {
                int[] tokens = input.Trim().Split().Select(int.Parse).ToArray();
                try
                {
                    rube[tokens[0], tokens[1], tokens[2]] += tokens[3];
                }
                catch (IndexOutOfRangeException)
                {
                }

                input = Console.ReadLine();
            }

            long unchangedCellsCounter = 0;
            long sumOfAllCells = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        sumOfAllCells += rube[i, j, k];
                        if (rube[i,j,k] == 0)
                        {
                            unchangedCellsCounter++;
                        }
                    }
                }
            }

            Console.WriteLine(sumOfAllCells);
            Console.WriteLine(unchangedCellsCounter);
        }

    }
}
