using System;
using System.Linq;
using System.Collections.Generic;

namespace FishingNet
{
    public class Net
    {
        private string material;
        private int capacity;
        private List<Fish> fish;

        public Net()
        {
            Fish = new List<Fish>();
        }

        public Net(string material, int capacity) : this()
        {
            Material = material;
            Capacity = capacity;
        }

        public string Material { get; set; }
        public int Capacity { get; set; }
        public List<Fish> Fish { get; set; }

        public int Count => Fish.Count;

        public string AddFish(Fish fish)
        {
            if (Fish.Count < Capacity)
            {
                if (fish.FishType != null && fish.FishType != " ")
                {
                    if (fish.Length > 0 && fish.Weight > 0)
                    {
                        Fish.Add(fish);
                        return $"Successfully added {fish.FishType} to the fishing net.";
                    }
                }

                return "Invalid fish.";
            }
            else
            {
                return "Fishing net is full.";
            }
        }

        public bool ReleaseFish(double weight)
        {
            for (int i = 0; i < Fish.Count; i++)
            {
                if (Fish[i].Weight == weight)
                {
                    Fish.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public Fish GetFish(string fishType)
        {
            Fish fish = new Fish("", 0, 0);

            foreach (Fish f in Fish)
            {
                if (f.FishType == fishType)
                {
                    fish = f;
                }
            }

            return fish;
        }

        public Fish GetBiggestFish()
        {
            Fish fish = new Fish("", 0, 0);

            foreach (Fish f in Fish)
            {
                if (f.Length > fish.Length)
                {
                    fish = f;
                }
            }

            return fish;
        }

        public void Report()
        {
            Fish = Fish.OrderByDescending(x => x.Length).ToList();

            Console.WriteLine($"Into the {Material}:");
            
            foreach (Fish f in Fish)
            {
                Console.WriteLine(f.ToString());
            }
        }
    }
}
