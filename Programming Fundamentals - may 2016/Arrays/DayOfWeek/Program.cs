using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};

            int dayOfWeek = int.Parse(Console.ReadLine());

            try
            {
                Console.WriteLine(days[dayOfWeek - 1]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Invalid Day!");
            }
        }
    }
}
