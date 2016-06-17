using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PopulationCounter
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

        public long TotalPopulation
        {
            get { return this.Cities.Sum(x => x.Population); }
        }

        public Country(string name)
        {
            this.Name = name;
            this.Cities = new List<City>();
        }

        public Country(string name, List<City> cities ) : this(name)
        {
            this.Cities = cities;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Country> countries = new List<Country>();

            string input = Console.ReadLine();

            while (input != "report")
            {
                var tokens = input.Split('|');
                string cityName = tokens[0];
                string countryName = tokens[1];
                long population = long.Parse(tokens[2]);
                var dummy = countries.FirstOrDefault(x => x.Name == countryName);

                if (dummy != null)
                {
                    dummy.Cities.Add(new City(cityName, population));
                }
                else
                {
                    var city = new City(cityName, population);
                    var country = new Country(countryName);
                    country.Cities.Add(city);
                    countries.Add(country);
                }
                input = Console.ReadLine();
            }

            foreach (var country in countries.OrderByDescending(x => x.TotalPopulation))
            {
                Console.WriteLine($"{country.Name} (total population: {country.TotalPopulation})");
                foreach (var city in country.Cities.OrderByDescending(x => x.Population))
                {
                    Console.WriteLine($"=>{city.Name}: {city.Population}");
                }
            }
        }
    }
}
