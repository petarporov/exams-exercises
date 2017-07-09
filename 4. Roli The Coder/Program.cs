using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _4.Roli_The_Coder
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventInfo = new Dictionary<int, Dictionary<string, List<string>>>();

            for (int i = 0; i < 1000; i++)
            {
                var tokken = Regex.Split(Console.ReadLine(), @"\s+");
                
                var playersInfo = new Dictionary<string, List<string>>();

                if (tokken[0] == "Time" && tokken[1] == "for" && tokken[2] == "Code")
                {
                    break;
                }
                var id = int.Parse(tokken[0]);
                var matchForName = Regex.Match(tokken[1], @"^#");

                var listOfPlayers = new List<string>();

                if (matchForName.Success)
                {
                    var eventName = tokken[1].Remove(0, 1);

                    if (!eventInfo.ContainsKey(id))
                    {
                        for (int j = 2; j < tokken.Length; j++)
                        {
                            var matchForParticipant = Regex.Match(tokken[j], "^@");
                            if (matchForParticipant.Success)
                            {
                                var playerName = tokken[j].Remove(0, 1);
                                listOfPlayers.Add(playerName);
                            }
                        }
                        listOfPlayers.Sort();
                        playersInfo.Add(eventName, listOfPlayers);
                        eventInfo.Add(id, playersInfo);
                    }
                    else if (eventInfo.ContainsKey(id) && eventInfo[id].ContainsKey(eventName))
                    {
                        for (int j = 2; j < tokken.Length; j++)
                        {
                            var matchForParticipant = Regex.Match(tokken[j], "^@");
                            if (matchForParticipant.Success)
                            {
                                var playerName = tokken[j].Remove(0, 1);
                                if (!eventInfo[id][eventName].Contains(playerName))
                                {
                                    listOfPlayers.Add(playerName);
                                }
                            }
                        }
                        listOfPlayers.AddRange(eventInfo[id][eventName]);
                        listOfPlayers.Sort();
                        eventInfo[id][eventName] = listOfPlayers;
                    }
                }
            }
            Console.WriteLine();

            var dsadas = eventInfo.Select(a => a.Value.OrderByDescending(b => b.Value));

            foreach (var item in eventInfo)
            {
                foreach (var parti in item.Value)
                {
                    Console.WriteLine($"{parti.Key.OrderByDescending(a => parti.Value.Count)}" +
                        $" - {parti.Value.Count}");
                }
            }

            Console.WriteLine();
        }
    }
}
