using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountWorkingDays
{
    class Program
    {
        static bool IsHoliday(DateTime day, DateTime[] holidays)
        {
            foreach (var d in holidays)
            {
                if (d.Day == day.Day && d.Month == day.Month)
                {
                    return true;
                }
            }
            return false;
        }

        static void Main(string[] args)
        {
            DateTime[] holidays =
            {
                new DateTime(2000, 1, 1),
                new DateTime(2000, 3, 3),
                new DateTime(2000, 5, 1),
                new DateTime(2000, 5, 6),
                new DateTime(2000, 5, 24),
                new DateTime(2000, 9, 6),
                new DateTime(2000, 9, 22),
                new DateTime(2000, 11, 1),
                new DateTime(2000, 12, 24),
                new DateTime(2000, 12, 25),
                new DateTime(2000, 12, 26),
            };

            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "d-M-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "d-M-yyyy", CultureInfo.InvariantCulture);

            int workingDays = 0;

            for (DateTime i = startDate; i <= endDate; i = i.AddDays(1))
            {
                if (i.DayOfWeek != DayOfWeek.Sunday && i.DayOfWeek != DayOfWeek.Saturday)
                {
                    if (!IsHoliday(i, holidays))
                    {
                        workingDays++;
                    }
                } 
            }

            Console.WriteLine(workingDays);
        }
    }
}
