using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private Dictionary<string, Pet> data;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new Dictionary<string, Pet>(capacity);
        }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Pet pet)
        {
            string key = $"{pet.Name}_{pet.Owner}";

            if (!data.ContainsKey(key) && Count + 1 <= Capacity)
            {
                data.Add(key, pet);
            }
        }

        public bool Remove(string name)
        {
            Pet toRemove = data.Values.FirstOrDefault(x => x.Name == name);

            if (toRemove == null)
            {
                return false;
            }

            string key = $"{toRemove.Name}_{toRemove.Owner}";

            return data.Remove(key);        
        }

        public Pet GetPet(string name, string owner)
        {
            string key = $"{name}_{owner}";

            return data.ContainsKey(key) ? data[key] : null;
        }

        public Pet GetOldestPet()
            => data.Values.OrderByDescending(x => x.Age).FirstOrDefault();

        public string GetStatistics()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("The clinic has the following patients:");

            foreach (var (_, pet) in data)
            {
                output.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return output.ToString().TrimEnd();
        
        }
    }
}
