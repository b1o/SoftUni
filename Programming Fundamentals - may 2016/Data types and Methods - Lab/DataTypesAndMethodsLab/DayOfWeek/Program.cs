using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOfWeek
{
    enum WeekDay
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (number > Enum.GetNames(typeof(WeekDay)).Length)
            {
                Console.WriteLine("Error");
            }
            else
            {
                Console.WriteLine((WeekDay)number);
            }
        }
    }
}
