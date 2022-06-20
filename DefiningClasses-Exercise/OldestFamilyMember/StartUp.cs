using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Family members = new Family();
            int inputNum = int.Parse(Console.ReadLine());
            if (inputNum == 0)
            {
                return;
            }

            for (int i = 0; i < inputNum; i++)
            {
                string[] personInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new Person(name, age);

                members.AddMember(person);
            }

            Person oldestMember = members.GetOldestMember();

            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}
