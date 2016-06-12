using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SoftUniCoffeeOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            long ordersCount = long.Parse(Console.ReadLine());
            decimal totalSum = 0;


            for (int i = 0; i < ordersCount; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                long capsuleCount = long.Parse(Console.ReadLine());

                decimal priceOfCoffee = (DateTime.DaysInMonth(orderDate.Year, orderDate.Month)*capsuleCount)*
                                        pricePerCapsule;

                totalSum += priceOfCoffee;
                Console.WriteLine($"The price for the coffee is: ${priceOfCoffee:f}");
            }

            Console.WriteLine($"Total: ${totalSum:f}");
        }
    }
}
