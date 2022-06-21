using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                string[] peopleInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = peopleInfo[0];
                int age = int.Parse(peopleInfo[1]);
                
                people.Add(new Person(name, age));
            }

            List<Person> sortedPeople = people.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();

            foreach  (Person person in sortedPeople)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
