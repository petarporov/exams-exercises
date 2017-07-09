using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation1
{
    class Program
    {
        static void Main(string[] args)
        {
            var leavingSoftuniTime = Console.ReadLine().Split(':');

            var numberSteps = int.Parse(Console.ReadLine());

            var timeForEachStep = int.Parse(Console.ReadLine());

            var leavingHour = int.Parse(leavingSoftuniTime[0]);
            var leavingMinute = int.Parse(leavingSoftuniTime[1]);
            var leavingSecond = int.Parse(leavingSoftuniTime[2]);

            double secondsToComeHome = numberSteps * timeForEachStep;
            var minutesToComeHome = 0.0;
            var hoursToComeHome = 0;
            var minutesToComeHomeEnd = 0;

            if (secondsToComeHome >= 60)
            {
                minutesToComeHome = secondsToComeHome / 60;
                minutesToComeHomeEnd = (int)minutesToComeHome;
                secondsToComeHome = (minutesToComeHome - (double)minutesToComeHomeEnd) * 60;
            }

            while (minutesToComeHomeEnd >= 60)
            {
                minutesToComeHomeEnd -= 60;
                hoursToComeHome++;
            }
            while (hoursToComeHome >= 24)
            {
                hoursToComeHome -= 24;
            }

            int secondsWhenComeHome = leavingSecond + (int)secondsToComeHome;
            var minutesWhenComeHome = minutesToComeHomeEnd + leavingMinute;
            var hoursToWhenComeHome = hoursToComeHome + leavingHour;

            while (secondsWhenComeHome >= 60)
            {
                secondsWhenComeHome -= 60;
                minutesWhenComeHome++;
            }

            while (minutesWhenComeHome >= 60)
            {
                minutesWhenComeHome-= 60;
                hoursToWhenComeHome++;
            }

            while (hoursToWhenComeHome >= 24)
            {
                hoursToWhenComeHome -= 24;
            }

            Console.WriteLine($"Time Arrival: {hoursToWhenComeHome:D2}:{minutesWhenComeHome:d2}" +
                $":{secondsWhenComeHome:d2}");
        }
    }
}
