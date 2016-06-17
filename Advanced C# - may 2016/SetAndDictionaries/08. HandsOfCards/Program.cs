using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.HandsOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: First test fails

            Dictionary<string, HashSet<string>> players = new Dictionary<string, HashSet<string>>();

            string input = Console.ReadLine();

            while (input != "JOKER")
            {
                string[] tokens = input.Trim()
                    .Split(new char[] {':', ' ', ','}, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                HashSet<string> cards = new HashSet<string>();

                for (int i = 1; i < tokens.Length; i++)
                {
                    cards.Add(tokens[i]);
                }

                if (players.ContainsKey(name))
                {
                    foreach (var card in cards)
                    {
                        players[name].Add(card);
                    }
                }
                else
                {
                    players.Add(name, cards);
                }

                input = Console.ReadLine();
            }

            foreach (var player in players)
            {
                Console.WriteLine($"{player.Key}: {CalculateScore(player.Value)}");
            }
        }

        public static long CalculateScore(HashSet<string> cards)
        {
            Dictionary<string, int> powers = new Dictionary<string, int>()
            {
                ["2"] = 2,
                ["3"] = 3,
                ["4"] = 4,
                ["5"] = 5,
                ["6"] = 6,
                ["7"] = 7,
                ["8"] = 8,
                ["9"] = 9,
                ["10"] = 10,
                ["J"] = 11,
                ["Q"] = 12,
                ["K"] = 13,
                ["A"] = 14
            };

            Dictionary<string, int> multipliers = new Dictionary<string, int>()
            {
                ["S"] = 4,
                ["H"] = 3,
                ["D"] = 2,
                ["C"] = 1
            };
            if (cards.Count > 1)
            {

                long score = 0;

                foreach (var card in cards)
                {
                    string power = card.Substring(0, card.Length - 1).ToUpper();
                    string multi = card[card.Length - 1].ToString().ToUpper();

                    score += powers[power] * multipliers[multi];
                }

                return score;
            }
            else
            {
                return 0;
            }
        }
    }
}
