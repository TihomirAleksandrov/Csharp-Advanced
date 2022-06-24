using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        private List<Animal> animals;
        private string name;
        private int capacity;

        public Zoo()
        {
            Animals = new List<Animal>();
        }

        public Zoo(string name, int capacity) : this()
        {
            Name = name;
            Capacity = capacity;
        }

        public List<Animal> Animals { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public string AddAnimal(Animal animal)
        {
            if (Animals.Count < Capacity)
            {
                if (animal.Species != null && animal.Species != " ")
                {
                    if (animal.Diet == "herbivore" || animal.Diet == "carnivore")
                    {
                        Animals.Add(animal);
                        return $"Successfully added {animal.Species} to the zoo.";
                    }
                    else
                    {
                        return "Invalid animal diet.";
                    }
                }
                else
                {
                    return "Invalid animal species.";
                }
            }
            else
            {
                return "The zoo is full.";
            }
        }

        public int RemoveAnimals(string species)
        {
            int removedCounter = 0;
            
            for (int i = 0; i < Animals.Count; i++)
            {
                if (Animals[i].Species == species)
                {
                    Animals.Remove(Animals[i]);
                    i--;
                    removedCounter++;
                }
            }

            return removedCounter;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return Animals.Where(x => x.Diet == diet).ToList();
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.FirstOrDefault(x => x.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int animalsCount = 0;

            foreach (Animal animal in Animals)
            {
                if (animal.Length >= minimumLength && animal.Length <= maximumLength)
                {
                    animalsCount++;
                }
            }

            return $"There are {animalsCount} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
