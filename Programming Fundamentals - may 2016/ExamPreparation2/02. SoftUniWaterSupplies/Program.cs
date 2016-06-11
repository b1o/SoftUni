using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SoftUniWaterSupplies
{
    class Bottle
    {
        public int Index { get; set; }
        public decimal AmountOfwater { get; set; }
        public int Capacity { get; set; }

        public bool IsFilled
        {
            get { return AmountOfwater == Capacity; }
        }

        public Bottle(int index, decimal amount, int capacity)
        {
            this.Index = index;
            this.AmountOfwater = amount;
            this.Capacity = capacity;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            decimal totalWater = decimal.Parse(Console.ReadLine());
            decimal[] bottles = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
            int bottleCapacity = int.Parse(Console.ReadLine());
            int totalWaterNeeded = bottleCapacity*bottles.Length;

            List<Bottle> trueBottles = new List<Bottle>();

            if (totalWater % 2 == 0)
            {
                for (int i = 0; i < bottles.Length; i++)
                {
                    decimal waterToFill = bottleCapacity - bottles[i];
                    if (totalWater - waterToFill < 0)
                    {
                        trueBottles.Add(new Bottle(i, bottles[i] + totalWater, bottleCapacity));
                        totalWater = 0;
                    }
                    else
                    {
                        trueBottles.Add(new Bottle(i, bottles[i] + waterToFill, bottleCapacity));
                        totalWater -= waterToFill;
                    }
                }
            }
            else
            {
                for (int i = bottles.Length - 1; i >= 0; i--)
                {
                    decimal waterToFill = bottleCapacity - bottles[i];
                    if (totalWater - waterToFill < 0)
                    {
                        trueBottles.Add(new Bottle(i, bottles[i] + totalWater, bottleCapacity));
                        totalWater = 0;
                    }
                    else
                    {
                        trueBottles.Add(new Bottle(i, bottles[i] + waterToFill, bottleCapacity));
                        totalWater -= waterToFill;
                    }
                }
            }

            var result = trueBottles.Where(x => !x.IsFilled);
            if (result.ToArray().Length > 0)
            {
                decimal waterNeeded = 0;
                foreach (var bottle in result)
                {
                    waterNeeded += Math.Abs(bottle.AmountOfwater - bottleCapacity);
                }
                Console.WriteLine("We need more water!");
                Console.WriteLine("Bottles left: " + result.ToArray().Length);
                Console.WriteLine("With indexes: " +
                                  string.Join(", ", trueBottles.Where(x => !x.IsFilled).Select(x => x.Index)));
                Console.WriteLine($"We need {waterNeeded} more liters!");
            }
            else
            {
                Console.WriteLine("Enough water!");
                Console.WriteLine($"Water left: {totalWater}l.");
            }
        }
    }
}
