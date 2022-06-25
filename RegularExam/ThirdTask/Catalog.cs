using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private string name;
        private int neededRenovators;
        private string project;
        private List<Renovator> renovators;

        public Catalog()
        {
            Renovators = new List<Renovator>();
        }

        public Catalog(string name, int neededRenovators, string project) : this()
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public List<Renovator> Renovators { get; set; }

        public int Count => Renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || renovator.Name == "")
            {
                return "Invalid renovator's information.";
            }
            else
            {
                if (Renovators.Count < NeededRenovators)
                {
                    if (renovator.Rate <= 350)
                    {
                        Renovators.Add(renovator);
                        return $"Successfully added {renovator.Name} to the catalog.";
                    }
                    else
                    {
                        return "Invalid renovator's rate.";
                    }
                }
                else
                {
                    return "Renovators are no more needed.";
                }
            }
        }

        public bool RemoveRenovator (string name)
        {
            if (Renovators.Any(x => x.Name == name))
            {
                Renovator renovator = Renovators.First(x => x.Name == name);
                return Renovators.Remove(renovator);
            }
            else
            {
                return false;
            }
        }

        public int RemoveRenovatorBySpecialty (string type)
        {
            int count = Renovators.Where(x => x.Type == type).Count();

            Renovators = Renovators.Where(x => x.Type != type).ToList();

            return count;
        }

        public Renovator HireRenovator(string name)
        {
            for (int i = 0; i < Renovators.Count; i++)
            {
                if (Renovators[i].Name == name)
                {
                    Renovators[i].Hired = true;
                    return Renovators[i];
                }
            }

            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            return Renovators.Where(x => x.Days >= days).ToList();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {Project}:");

            foreach (Renovator renovator in Renovators.Where(x => x.Hired == false))
            {
                sb.AppendLine(renovator.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
