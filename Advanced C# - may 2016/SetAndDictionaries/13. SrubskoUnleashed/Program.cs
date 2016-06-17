using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _13.SrubskoUnleashed
{
    class Singer
    {
        public string Name { get; set; }
        public decimal totalIncome { get; set; }

        public Singer(string name, decimal income)
        {
            this.Name = name;
            this.totalIncome = income;
        }
    }

    class Venue
    {
        public string Name { get; set; }
        public List<Singer> Singers { get; set; }

        public Venue(string name)
        {
            this.Name = name;
            this.Singers = new List<Singer>();
        }

        public void AddSinger(Singer singer)
        {
            var dummy = this.Singers.FirstOrDefault(x => x.Name == singer.Name);
            if (dummy != null)
            {
                dummy.totalIncome += singer.totalIncome;
            }
            else
            {
                this.Singers.Add(singer);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string patten = @"^(.*)\s@(.*)\s(\d+)\s(\d+)$";

            List<Venue> venues = new List<Venue>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                Match match = Regex.Match(input, patten);
                if (match.Success)
                {
                    string singerName = match.Groups[1].Value;
                    string venueName = match.Groups[2].Value;
                    decimal ticketPrice = decimal.Parse(match.Groups[3].Value);
                    int ticketCount = int.Parse(match.Groups[4].Value);

                    decimal income = ticketCount*ticketPrice;
                    var dummy = venues.FirstOrDefault(x => x.Name == venueName);
                    if (dummy != null)
                    {
                        dummy.AddSinger(new Singer(singerName, income));   
                    }
                    else
                    {
                        Venue venue = new Venue(venueName);
                        venue.AddSinger(new Singer(singerName, income));
                        venues.Add(venue);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var venue in venues)
            {
                Console.WriteLine($"{venue.Name}");
                foreach (var singer in venue.Singers.OrderByDescending(x => x.totalIncome))
                {
                    Console.WriteLine($"#  {singer.Name} -> {singer.totalIncome}");
                }
            }
        }
    }
}
