using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace _04.TrifonQuest
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }


    }

    class Trifon
    {
        private long health;

        public Point Position { get; set; }
        public bool isMovingDown { get; set; }
        public long MaxHealth { get; set; }

        public bool CanMove
        {
            get
            {
                if (this.turnsToWait != 0)
                {
                    return false;
                }
                return true;
            }
        }

        public int turnsToWait { get; set; }

        public long Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                if (this.Health > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public Trifon(long health)
        {
            this.Health = health;
            this.MaxHealth = health;
            this.Position = new Point(0, 0);
            this.isMovingDown = true;
        }

        public void Move(List<List<char>> field)
        {
            if (isMovingDown)
            {
                if (this.Position.Y + 1 > field.Count - 1)
                {
                    this.Position.Y = field.Count - 1;
                    this.Position.X++;
                    isMovingDown = false;
                }
                else
                {
                    this.Position.Y++;
                }
            }
            else
            {
                if (this.Position.Y - 1 < 0)
                {
                    this.Position.Y = 0;
                    this.Position.X++;

                    isMovingDown = true;
                }
                else
                {
                    this.Position.Y--;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Trifon trifon = new Trifon(long.Parse(Console.ReadLine()));
            var field = GetPlayField();
            bool completed = true;

            int currentTurns = 0;
            int cellsToWin = field[0].Count*field.Count;
            int cellsMoved = 0;


            AffectTrifon(trifon, field[0][0], currentTurns);
            

            while (cellsMoved != cellsToWin)
            {
                if (trifon.IsAlive)
                {
                    currentTurns++;
                    if (!trifon.CanMove)
                    {
                        trifon.turnsToWait--;
                    }
                    else
                    {
                        trifon.Move(field);
                        cellsMoved++;
                        try
                        {
                            AffectTrifon(trifon, field[trifon.Position.Y][trifon.Position.X], currentTurns);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            //The Position.X goes +1 after the end of the field on some occasions
                        }
                    }
                }
                else
                {
                    completed = false;
                    break;
                }
            }

            if (completed)
            {
                Console.WriteLine("Quest completed!");
                Console.WriteLine($"Health: {trifon.Health}");
                Console.WriteLine($"Turns: {currentTurns}");
            }
            else
            {
                Console.WriteLine($"Died at: [{trifon.Position.Y}, {trifon.Position.X}]");
            }

        }

        public static void AffectTrifon(Trifon trifon, char tile, int currentTurns)
        {
            switch (tile)
            {
                case 'F':
                    trifon.Health -= (int)(currentTurns/2);
                    break;
                case 'H':
                    trifon.Health += (int)(currentTurns/3);
                    break;
                case 'T':
                    trifon.turnsToWait = 2;
                    break;
            }
        }

        public static List<List<char>>  GetPlayField()
        {
            long[] dimensions = Console.ReadLine().Split().Select(long.Parse).ToArray();
            List<List<char>> field = new List<List<char>>();

            for (int i = 0; i < dimensions[0]; i++)
            {
                field.Add(Console.ReadLine().ToList());
            }
            return field;
        }
    }
}
