using System;
using System.Linq;
using System.Collections.Generic;

namespace FilterByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> peopleInfo = new Dictionary<string, int>();
            int inputNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputNum; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = input[0];
                int age = int.Parse(input[1]);
                peopleInfo.Add(name, age);
            }

            peopleInfo = Filter(peopleInfo);
            Print(peopleInfo);
        }

        static Dictionary<string, int> Filter(Dictionary<string, int> peopleInfo)
        {
            string condition = Console.ReadLine();
            int ageRequired = int.Parse(Console.ReadLine());

            if (condition == "older")
            {
                peopleInfo = peopleInfo.Where(x => x.Value >= ageRequired).ToDictionary(x => x.Key, x => x.Value);
            }
            else if (condition == "younger")
            {
                peopleInfo = peopleInfo.Where(x => x.Value < ageRequired).ToDictionary(x => x.Key, x => x.Value);
            }

            return peopleInfo;
        }

        static void Print(Dictionary<string, int> peopleInfo)
        {
            string format = Console.ReadLine();

            if (format == "name")
            {
                Console.WriteLine(string.Join("\n", peopleInfo.Keys
                    ));
            }
            else if (format == "age")
            {
                Console.WriteLine(string.Join("\n", peopleInfo.Values
                    ));
            }
            else if (format == "name age")
            {
                foreach (var pair in peopleInfo)
                {
                    Console.WriteLine($"{pair.Key} - {pair.Value}");
                }
            }
        }
    }
}
