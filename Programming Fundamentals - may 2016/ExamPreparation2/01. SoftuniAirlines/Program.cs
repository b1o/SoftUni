using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SoftuniAirlines
{
    class Program
    {
        static void Main(string[] args)
        {
            int flightsToManage = int.Parse(Console.ReadLine());

            decimal overallProfit = 0;

            for (int i = 0; i < flightsToManage; i++)
            {
                int adultPassangersCount = int.Parse(Console.ReadLine());
                decimal adultTicketPrice = decimal.Parse(Console.ReadLine());
                int youthPassengerCount = int.Parse(Console.ReadLine());
                decimal youthTicketPrice = decimal.Parse(Console.ReadLine());
                decimal fuelPricePerHour = decimal.Parse(Console.ReadLine());
                decimal fuelCOnsumptionPerHour = decimal.Parse(Console.ReadLine());
                int flightDuration = int.Parse(Console.ReadLine());

                var income = (adultPassangersCount*adultTicketPrice) + (youthPassengerCount*youthTicketPrice);
                var expenses = flightDuration*fuelCOnsumptionPerHour*fuelPricePerHour;

                if (income > expenses)
                {
                    Console.WriteLine($"You are ahead with {income - expenses:F3}$.");
                    overallProfit += income - expenses;
                }
                else
                {
                    Console.WriteLine($"We've got to sell more tickets! We've lost -{expenses - income:F3}$.");
                    overallProfit -= expenses - income;
                }
            }

            Console.WriteLine($"Overall profit -> {overallProfit:F3}$.");
            Console.WriteLine($"Average profit -> {overallProfit / flightsToManage:F3}$.");


        }
    }
}
