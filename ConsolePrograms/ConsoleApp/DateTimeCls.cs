using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class DateTimeCls
    {
        public void DateTimeDiff()
        {
            // Define the two date-time values
            DateTime firstDateTime = new DateTime(2024, 1, 29, 9, 43, 21);
            DateTime secondDateTime = new DateTime(2024, 2, 1, 9, 55, 0);

            // Calculate the time difference
            TimeSpan timeDifference = secondDateTime - firstDateTime;

            // Output the difference
            Console.WriteLine("Time Difference: " + timeDifference.TotalHours);

            Console.WriteLine("Time Difference: {0} days, {1} hours, {2} minutes, {3} seconds",
                            timeDifference.Days,
                            timeDifference.Hours,
                            timeDifference.Minutes,
                            timeDifference.Seconds);
            
        }
    }
}
