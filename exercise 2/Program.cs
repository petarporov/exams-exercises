using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var allPlayers = Regex.Split(Console.ReadLine(), @"\s*,\s*");

            var allSongs = Console.ReadLine().Split(',').Select(s => s.Trim()).ToArray();

            var awardsByPlayers = new Dictionary<string, List<string>>();
            bool empty = true;

            foreach (var p in allPlayers)
            {
                awardsByPlayers[p] = new List<string>();
            }

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "dawn")
                {
                    break;
                }

                var tokkens = Regex.Split(command, @"\s*,\s*");
                var player = tokkens[0];
                var song = tokkens[1];
                var award = tokkens[2];

                if (allPlayers.Contains(player) && allSongs.Contains(song))
                {
                    awardsByPlayers[player].Add(award);
                }
            }

            var personsWithAwards = awardsByPlayers.OrderByDescending(item => item.Value.Count)
                .ThenBy(item => item.Key);
            var result = personsWithAwards.ToDictionary(c => c.Key, c => c.Value.Distinct().ToList());

            foreach (var p in result)
            {
                if (p.Value.Count > 0)
                {
                    Console.WriteLine(p.Key + ": " + p.Value.Count + " awards");
                    Console.Write("--");
                    Console.WriteLine(string.Join("\r\n--", p.Value));
                    empty = false;
                }
            }
            if (empty)
            {
                Console.WriteLine("No awards");
            }
        }
    }
}
