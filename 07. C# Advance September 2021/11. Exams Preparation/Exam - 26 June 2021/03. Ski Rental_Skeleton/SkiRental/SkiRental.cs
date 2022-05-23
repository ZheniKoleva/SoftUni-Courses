using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private Dictionary<string, Ski> data;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new Dictionary<string, Ski>(capacity);
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;


        public void Add(Ski ski)
        {
            string key = $"{ski.Manufacturer}_{ski.Model}";

            if (!data.ContainsKey(key) && Count + 1 <= Capacity)
            {
                data.Add(key, ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            string key = $"{manufacturer}_{model}";

            return data.Remove(key);
        }

        public Ski GetNewestSki()
            => data.Values.OrderByDescending(x => x.Year).FirstOrDefault();

        public Ski GetSki(string manufacturer, string model)
        {
            string key = $"{manufacturer}_{model}";

            return data.ContainsKey(key) ? data[key] : null;
        }

        public string GetStatistics()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"The skis stored in {Name}:");

            foreach (var (_ ,ski) in data)
            {
                output.AppendLine(ski.ToString());
            }

            return output.ToString().TrimEnd();
        }

    }
}
