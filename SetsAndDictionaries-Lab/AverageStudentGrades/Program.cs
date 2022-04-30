using System;
using System.Linq;
using System.Collections.Generic;

namespace AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> grades = new Dictionary<string, List<decimal>>();

            int inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                string[] studentInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string studentName = studentInfo[0];
                decimal grade = decimal.Parse(studentInfo[1]);

                if (grades.ContainsKey(studentName))
                {
                    grades[studentName].Add(grade);
                }
                else
                {
                    grades.Add(studentName, new List<decimal>());
                    grades[studentName].Add(grade);
                }
            }

            foreach (var pair in grades)
            {
                Console.Write($"{pair.Key} -> ");
                foreach (decimal grade in pair.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.Write($"(avg: {pair.Value.Average():f2})");
                Console.WriteLine();
            }
        }
    }
}
