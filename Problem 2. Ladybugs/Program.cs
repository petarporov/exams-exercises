using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Ladybugs
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeOfField = int.Parse(Console.ReadLine());
            var indexesOfBugs = Console.ReadLine().Split().Select(int.Parse).ToArray();
       
            var command = Console.ReadLine().Split();
            var endArray = new int[sizeOfField];

            for (int i = 0; i < endArray.Length; i++)
            {
                if (indexesOfBugs.Contains(i))
                    endArray[i] = i;
                else
                    endArray[i] = -1;
            }

            while (command[0] != "end")
            {
                var ladyBugIndex = int.Parse(command[0]);
                var direction = command[1];
                var flyLength = int.Parse(command[2]);
                var bugToFlyIndex = 0;

                if (direction == "right" && endArray.Contains(ladyBugIndex))
                {
                    bugToFlyIndex = ladyBugIndex + flyLength;
                    for (int i = 0; i < endArray.Length; i++)
                    {
                        if (endArray[i] == ladyBugIndex)
                        {
                            endArray[i] = -1;

                            if (bugToFlyIndex < sizeOfField && endArray[bugToFlyIndex] < 0)
                            {
                                endArray[bugToFlyIndex] = bugToFlyIndex;
                                break;
                            }
                            else if (bugToFlyIndex < sizeOfField && endArray[bugToFlyIndex] >= 0)
                            {
                                for (int j = bugToFlyIndex; j < endArray.Length; j++)
                                {
                                    if (endArray[j] < 0)
                                    {
                                        endArray[j] = j;
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                }

                if (direction == "left" && endArray.Contains(ladyBugIndex))
                {
                    bugToFlyIndex = ladyBugIndex - flyLength;
                    for (int i = 0; i < endArray.Length; i++)
                    {
                        if (endArray[i] == ladyBugIndex)
                        {
                            endArray[i] = -1;
                            if (bugToFlyIndex >= 0)
                            {
                                if (bugToFlyIndex < sizeOfField && endArray[bugToFlyIndex] < 0)
                                {
                                    endArray[bugToFlyIndex] = bugToFlyIndex;
                                    break;
                                }
                                else if (bugToFlyIndex < sizeOfField && endArray[bugToFlyIndex] >= 0)
                                {
                                    for (int j = bugToFlyIndex; j > 0; j--)
                                    {
                                        if (endArray[j] < 0)
                                        {
                                            endArray[j] = j;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

                command = Console.ReadLine().Split();
            }
            for (int i = 0; i < endArray.Length; i++)
            {
                if (endArray[i] < 0)
                {
                    endArray[i] = 0;
                }
                else
                {
                    endArray[i] = 1;
                }
            }
            Console.WriteLine(string.Join(" ", endArray));
        }
    }
}
