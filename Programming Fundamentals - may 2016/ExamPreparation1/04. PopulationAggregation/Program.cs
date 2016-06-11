using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _04.PopulationAggregation
{
    class City
    {
        public string Name { get; set; }
        public long Population { get; set; }

        public City(string name, long population)
        {
            this.Name = name;
            this.Population = population;
        }
    }

    class Country
    {
        public string Name { get; set; }
        public List<City> Cities { get; set; }

        public City biggestCity
        {
            get { return Cities.Aggregate((i1, i2) => i1.Population > i2.Population ? i1 : i2); }
        }

        public Country(string name)
        {
            this.Name = name;
            this.Cities = new List<City>();
        }

        public Country(string name, List<City> cities) : this(name)
        {
            this.Cities = cities;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Country> countries = new List<Country>();

            while (input != "stop")
            {
                string[] commandTokens = input.Split('\\');
                commandTokens[0] = ClearWord(commandTokens[0]);
                commandTokens[1] = ClearWord(commandTokens[1]);

                long population = long.Parse(commandTokens[2]);
                string contryName = "";
                string cityName = "";


                if (char.IsUpper(commandTokens[0][0]))
                {
                    contryName = commandTokens[0];
                    cityName = commandTokens[1];
                }
                else
                {
                    contryName = commandTokens[1];
                    cityName = commandTokens[0];
                }

                if (countries.All(x => x.Name != contryName))
                {
                    Country country = new Country(contryName);
                    country.Cities.Add(new City(cityName, population));
                    countries.Add(country);
                }
                else
                {
                    var currentCountry = countries.Find(x => x.Name == contryName);
                    if (currentCountry.Cities.FirstOrDefault(x => x.Name == cityName) == null)
                    {
                        currentCountry.Cities.Add(new City(cityName, population));
                    }
                    else
                    {
                        currentCountry.Cities.Find(x => x.Name == cityName).Population = population;
                        currentCountry.Cities.Add(new City(cityName, population));
                    }
                }

                input = Console.ReadLine();
            }

            List<City> allCities = new List<City>();

            foreach (var country in countries.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{country.Name} -> {country.Cities.Count}");
                foreach (var city in country.Cities)
                {
                    allCities.Add(city);
                }
            }

            var biggestCities = allCities.OrderByDescending(x => x.Population).GroupBy(x => x.Name).Select(s => s.First()).Take(3);

            foreach (var city in biggestCities)
            {
                Console.WriteLine($"{city.Name} -> {city.Population}");
            }
        }

        public static string ClearWord(string word)
        {
            char[] charsToRemove = {'@', '#', '$', '&'};
            string result = "";

            foreach (var l in word)
            {
                if (!charsToRemove.Contains(l) && !char.IsDigit(l))
                {
                    result += l;
                }
            }

            return result;
        }
    }
}
