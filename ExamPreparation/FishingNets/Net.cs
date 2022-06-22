using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

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
            if (Fish.Any(x => x.Weight == weight))
            {
                Fish fish = Fish.First(x => x.Weight == weight);
                return Fish.Remove(fish);
            }

            return false;
        }

        public Fish GetFish(string fishType)
        {
            return Fish.FirstOrDefault(x => x.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            return Fish.OrderByDescending(x => x.Length).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Into the {Material}:");

            foreach (Fish fish in Fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
