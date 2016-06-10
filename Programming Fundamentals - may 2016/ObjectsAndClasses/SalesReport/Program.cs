using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReport
{
    class Sale
    {
        public Sale(string town, string product, decimal price, double quantity)
        {
            this.Town = town;
            this.Product = product;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Town { get; set; }

        public string Product { get; set; }

        public decimal Price { get; set; }

        public double Quantity { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSales = int.Parse(Console.ReadLine());
            List<Sale> sales = new List<Sale>();

            for (int i = 0; i < numberOfSales; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ').ToArray();
                Sale sale = new Sale(tokens[0], tokens[1], decimal.Parse(tokens[2], CultureInfo.InvariantCulture), double.Parse(tokens[3], CultureInfo.InvariantCulture));
                sales.Add(sale);
            }

            var result = sales.Select(x => x.Town).Distinct().OrderBy(x => x);
            foreach (var town in result)
            {
                decimal sum = sales.Where(x => x.Town == town).Select(x => x.Price*(decimal)x.Quantity).Sum();
                Console.WriteLine($"{town} -> {sum:f}");
            }
        }
    }
}
