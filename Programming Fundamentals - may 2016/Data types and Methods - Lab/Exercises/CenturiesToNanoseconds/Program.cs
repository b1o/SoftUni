using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenturiesToNanoseconds
{
    class Program
    {
        static void Main(string[] args)
        {
            uint centuries = uint.Parse(Console.ReadLine());
            uint years = centuries*100;
            uint days = (uint)(years*365.2422);
            uint hours = days*24;
            ulong minutes = hours*60;
            ulong seconds = minutes*60;
            ulong milliseconds = seconds*1000;
            ulong microseconds = milliseconds*1000;
            ulong nanoseconds = microseconds*1000;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
        }
    }
}
