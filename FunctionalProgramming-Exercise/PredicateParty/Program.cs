using System;
using System.Linq;
using System.Collections.Generic;

namespace PredicateParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine();

            while (input != "Party!")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (command[0] == "Double")
                {
                    if (command[1] == "StartsWith")
                    {
                        string start = command[2];
                        names = DoubleStart(names, start);
                    }
                    else if (command[1] == "EndsWith")
                    {
                        string end = command[2];
                        names = DoubleEnd(names, end);
                    }
                    else if (command[1] == "Length")
                    {
                        int length = int.Parse(command[2]);
                        names = DoubleLength(names, length);
                    }
                }
                else if (command[0] == "Remove")
                {
                    if (command[1] == "StartsWith")
                    {
                        string start = command[2];
                        names = RemoveStart(names, start);
                    }
                    else if (command[1] == "EndsWith")
                    {
                        string end = command[2];
                        names = RemoveEnd(names, end);
                    }
                    else if (command[1] == "Length")
                    {
                        int length = int.Parse(command[2]);
                        names = RemoveLength(names, length);
                    }
                }

                input = Console.ReadLine();
            }

            if (names.Count != 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static List<string> DoubleStart(List<string> names, string start)
        {
            Predicate<string> condition = x => x.Substring(0, start.Length) == start;

            for (int i = 0; i < names.Count; i++)
            {
                if (condition(names[i]))
                {
                    names.Insert(i, names[i]);
                    i++;
                }
            }

            return names;
        }

        static List<string> DoubleEnd(List<string> names, string end)
        {
            Predicate<string> condition = x => x.Substring(x.Length - end.Length) == end;

            for (int i = 0; i < names.Count; i++)
            {
                if (condition(names[i]))
                {
                    names.Insert(i, names[i]);
                    i++;
                }
            }

            return names;
        }

        static List<string> DoubleLength(List<string> names, int length)
        {
            Predicate<string> condition = x => x.Length == length;

            for (int i = 0; i < names.Count; i++)
            {
                if (condition(names[i]))
                {
                    names.Insert(i, names[i]);
                    i++;
                }
            }

            return names;
        }

        static List<string> RemoveStart(List<string> names, string start)
        {
            Predicate<string> condition = x => x.Substring(0, start.Length) == start;

            for (int i = 0; i < names.Count; i++)
            {
                if (condition(names[i]))
                {
                    names.Remove(names[i]);
                    i--;
                }
            }

            return names;
        }

        static List<string> RemoveEnd(List<string> names, string end)
        {
            Predicate<string> condition = x => x.Substring(x.Length - end.Length) == end;

            for (int i = 0; i < names.Count; i++)
            {
                if (condition(names[i]))
                {
                    names.Remove(names[i]);
                    i--;
                }
            }

            return names;
        }

        static List<string> RemoveLength(List<string> names, int length)
        {
            Predicate<string> condition = x => x.Length == length;

            for (int i = 0; i < names.Count; i++)
            {
                if (condition(names[i]))
                {
                    names.Remove(names[i]);
                    i--;
                }
            }

            return names;
        }
    }
}
