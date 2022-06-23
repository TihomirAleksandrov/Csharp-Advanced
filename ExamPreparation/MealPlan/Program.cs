using System;
using System.Linq;
using System.Collections.Generic;

namespace MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> menu = new Dictionary<string, int>()
            {
                {"salad", 350},
                {"soup", 490},
                {"pasta", 680},
                {"steak", 790}
            };

            string[] mealInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Queue<string> meals = new Queue<string>(mealInput);

            int[] caloriesInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            Stack<int> calories = new Stack<int>(caloriesInput);


            int mealsCount = 0;

            while (true)
            {
                if (meals.Count == 0)
                {
                    break;
                }

                int todaysCalories = calories.Pop();
                int mealCalories = menu[meals.Dequeue()];

                int caloriesLeft = todaysCalories - mealCalories;

                if (caloriesLeft > 0)
                {
                    todaysCalories = caloriesLeft;
                }
                else
                {
                    if (calories.Count > 0)
                    {
                        todaysCalories = calories.Pop();
                        todaysCalories -= Math.Abs(caloriesLeft);
                    }
                    else
                    {
                        mealsCount++;
                        break;
                    }
                }

                calories.Push(todaysCalories);
                mealsCount++;
            }

            if (calories.Count == 0)
            {
                Console.WriteLine($"John ate enough, he had {mealsCount} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
            else if (meals.Count == 0)
            {
                Console.WriteLine($"John had {mealsCount} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
        }
    }
}
