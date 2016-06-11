    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;

    namespace _01.SweetDesert
    {
        class Program
        {
            static void Main(string[] args)
            {
                decimal amountOfMoney = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                int numberOfGuests = int.Parse(Console.ReadLine());
                decimal priceOfBanana = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                decimal priceOfEgg = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                decimal priceOfBerries = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); //For a kilo

                decimal moneyForSixPack = (2 * priceOfBanana) + (4 * priceOfEgg) + (0.2m * priceOfBerries);

                int sixPacksToMake = (int)Math.Ceiling((double)numberOfGuests / 6);

                if (amountOfMoney >= moneyForSixPack*sixPacksToMake)
                {
                    Console.WriteLine($"Ivancho has enough money - it would cost {moneyForSixPack*sixPacksToMake:f}lv.");
                }
                else
                {
                    Console.WriteLine($"Ivancho will have to withdraw money - he will need {((moneyForSixPack*sixPacksToMake) - amountOfMoney):f}lv more.");
                }
            }
        }
    }
