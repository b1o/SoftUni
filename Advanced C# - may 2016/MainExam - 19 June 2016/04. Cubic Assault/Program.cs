using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Cubic_Assault
{
    class MeteorType
    {
        public string Name { get; set; }
        public long quanty { get; set; }

        public MeteorType(string name, long quantity)
        {
            this.Name = name;
            this.quanty = quantity;
        } 
    }

    class Region
    {
        public string Name { get; set; }
        public Dictionary<string, long> Meteors { get; set; }

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

        public void AddMeteor(string type, long quantity)
        {
            this.Meteors[type] += quantity;
            if (this.Meteors[type] >= 1000000)
            {
                switch (type)
                {
                    case "Green":
                        this.Meteors["Red"] += this.Meteors["Green"]/1000000;
                        this.Meteors["Green"] = this.Meteors["Green"]%1000000;
                        if (this.Meteors["Red"] >= 1000000)
                        {
                            this.Meteors["Black"] += this.Meteors["Red"]/1000000;
                            this.Meteors["Red"] = this.Meteors["Red"]%1000000;
                        }
                        break;
                    case "Red":
                        this.Meteors["Black"] += this.Meteors["Red"]/1000000;
                        this.Meteors["Red"] = this.Meteors["Red"]%1000000;
                        break;
                }
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Region> regions = new List<Region>();

            string input = Console.ReadLine();

            while (input != "Count em all")
            {
                string[] tokens = input.Trim().Split(new string[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
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
