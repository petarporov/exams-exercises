using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3___Endurance_Rally
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split();

            var zones = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var checkpoints = Console.ReadLine().Split().Select(int.Parse);

            var driversFuel = new Dictionary<string, double>();

            var leftDriversFuel = new Dictionary<string, double>();

            var driversWithNoFuel = new Dictionary<string, double>();

            var driverFinishedTheRace = new Dictionary<string, bool>();

            for (int i = 0; i < names.Length; i++)
            {
                int fuelForDriver = (char)names[i].First();
                driversFuel[names[i]] = fuelForDriver;
                leftDriversFuel[names[i]] = fuelForDriver;
                driverFinishedTheRace[names[i]] = true;
            }
            //initializing of dicts

            for (int i = 0; i < zones.Length; i++)
            {
                var fuelFromZone = zones[i];

                if (checkpoints.Contains(i))
                {
                    foreach (var driver in driversFuel)
                    {
                        if (driver.Value > 0 && driverFinishedTheRace[driver.Key] == true)
                        {
                            leftDriversFuel[driver.Key] = driver.Value + fuelFromZone;
                        }
                        else
                        {
                            if (driverFinishedTheRace[driver.Key] == true)
                                leftDriversFuel[driver.Key] = -1;

                            driverFinishedTheRace[driver.Key] = false;
                        }
                    }
                }
                else
                {
                    foreach (var driver in driversFuel)
                    {
                        if (leftDriversFuel[driver.Key] > 0 && driverFinishedTheRace[driver.Key])
                            leftDriversFuel[driver.Key] = driver.Value - fuelFromZone;

                        if (leftDriversFuel[driver.Key] <= 0)
                        {
                            if (driverFinishedTheRace[driver.Key] == true)
                                leftDriversFuel[driver.Key] = -1;

                            driverFinishedTheRace[driver.Key] = false;
                        }
                    }
                }

                foreach (var driver in leftDriversFuel)
                {
                    if (!driverFinishedTheRace[driver.Key] && driver.Value < 0)
                        driversFuel[driver.Key] = i;
                    else
                        driversFuel[driver.Key] = driver.Value;
                }

                foreach (var driver in driversFuel)
                {
                    leftDriversFuel[driver.Key] = driver.Value;
                }
            }

            foreach (var driver in driversFuel)
            {
                if (driverFinishedTheRace[driver.Key])
                    Console.WriteLine($"{driver.Key} - fuel left {driver.Value:f2}");

                else
                    Console.WriteLine($"{driver.Key} - reached {driver.Value}");
            }

        }
    }
}
