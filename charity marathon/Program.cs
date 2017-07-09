using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace charity_marathon
{
    class Program
    {
        static void Main(string[] args)
        {
            var marathonDays = int.Parse(Console.ReadLine());
            var runnerToParticipate = int.Parse(Console.ReadLine());
            var numberOfLaps = int.Parse(Console.ReadLine());
            var lengthOfTrack = int.Parse(Console.ReadLine());
            var capacityOfTrack = int.Parse(Console.ReadLine());
            var moneyDonatedKM = double.Parse(Console.ReadLine());

            capacityOfTrack = capacityOfTrack * marathonDays;

            if (runnerToParticipate > capacityOfTrack)
            {
                runnerToParticipate = capacityOfTrack;
            }

            BigInteger totalMetersRuning = runnerToParticipate * numberOfLaps * lengthOfTrack;
            double totalKMRuning = (double)totalMetersRuning / 1000;

            double moneyRaised = totalKMRuning * moneyDonatedKM;

            Console.WriteLine($"Money raised: {moneyRaised:f2}");
        }
    }
}
