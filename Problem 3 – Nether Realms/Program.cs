using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Problem_3___Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            var demonName = Regex.Split(Console.ReadLine(), @"\s*,\s*");

            var patternForSymbols = new Regex(@"^[^\d\+\-\*/\.]+$");

            var patternForNumbers = new Regex(@"[-\d\.]+");

            SortedDictionary<string, int> demonHealth = new SortedDictionary<string, int>();

            var demonsDamage = new SortedDictionary<string, double>();


            for (int i = 0; i < demonName.Length; i++)
            {
                var health = 0;
                var demonChar = demonName[i].ToCharArray();
                double demonDMG = 0;

                for (int j = 0; j < demonChar.Length; j++)
                {
                    string symbol = demonChar[j].ToString();
                    var match = patternForSymbols.Match(symbol);

                    if (match.Success)
                    {
                        health += demonChar[j];
                    }
                }
                demonHealth[demonName[i]] = health;

                var matches = patternForNumbers.Matches(demonName[i])
                       .Cast<Match>()
                       .ToArray();

                foreach (var match in matches)
                {
                    var dmg = match.Value;
                    double intdmg = double.Parse(dmg);
                    demonDMG += intdmg;
                }

                var matchesForDelene = Regex.Matches(demonName[i], @"/");
                foreach (var match in matchesForDelene)
                {
                    demonDMG /= 2;
                }

                var matchesForMultiplying = Regex.Matches(demonName[i], @"\*");
                foreach (var match in matchesForMultiplying)
                {
                    demonDMG *= 2;
                }
                demonsDamage[demonName[i]] = demonDMG;
            }

            foreach (var demons in demonHealth)
            {
                Console.Write($"{demons.Key} - {demons.Value} health, ");
                foreach (var dmg in demonsDamage)
                {
                    if (demons.Key == dmg.Key)
                    {
                        Console.WriteLine($"{dmg.Value:F2} damage");
                    }
                }
            }
        }
    }
}
