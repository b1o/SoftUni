namespace _04.Cubic_Assault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Region
    {
        private const int CurrencyTransformThreshold = 1000000;

        public Region(string name)
        {
            this.Name = name;
            this.Meteors = new Dictionary<string, long>()
            {
                ["Green"] = 0,
                ["Red"] = 0,
                ["Black"] = 0
            };
        }

        public string Name { get; set; }

        public Dictionary<string, long> Meteors { get; set; }

        public void AddMeteor(string type, long quantity)
        {
            this.Meteors[type] += quantity;
            if (this.Meteors[type] >= CurrencyTransformThreshold)
            {
                ////TODO: There should be a better way to do this. But if it looks stupid and it works, it ain't stupid!
                switch (type)
                {
                    case "Green":
                        this.Meteors["Red"] += this.Meteors["Green"] / CurrencyTransformThreshold;
                        this.Meteors["Green"] = this.Meteors["Green"] % CurrencyTransformThreshold;
                        if (this.Meteors["Red"] >= 1000000)
                        {
                            this.Meteors["Black"] += this.Meteors["Red"] / CurrencyTransformThreshold;
                            this.Meteors["Red"] = this.Meteors["Red"] % CurrencyTransformThreshold;
                        }

                        break;
                    case "Red":
                        this.Meteors["Black"] += this.Meteors["Red"] / CurrencyTransformThreshold;
                        this.Meteors["Red"] = this.Meteors["Red"] % CurrencyTransformThreshold;
                        break;
                }
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Region> regions = new List<Region>();

            string input = Console.ReadLine();

            while (input != "Count em all")
            {
                string[] tokens = input.Trim().Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string regionName = tokens[0];
                string meteorType = tokens[1];
                long quantity = long.Parse(tokens[2]);

                var dummy = regions.FirstOrDefault(x => x.Name == regionName);

                if (dummy != null)
                {
                    dummy.AddMeteor(meteorType, quantity);
                }
                else
                {
                    var region = new Region(regionName);
                    region.AddMeteor(meteorType, quantity);
                    regions.Add(region);
                }

                input = Console.ReadLine();
            }

            foreach (var region in regions.OrderByDescending(x => x.Meteors["Black"]).ThenBy(x => x.Name.Length).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{region.Name}");
                foreach (var meteor in region.Meteors.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {meteor.Key} : {meteor.Value}");
                }
            }
        }
    }
}
