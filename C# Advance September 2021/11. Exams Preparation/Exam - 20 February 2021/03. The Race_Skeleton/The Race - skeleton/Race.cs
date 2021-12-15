using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private HashSet<Racer> data;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new HashSet<Racer>(capacity);
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Racer racer)
        {
            if (Count + 1 <= Capacity)
            {
                data.Add(racer);
            }
        }

        public bool Remove(string name) => data.RemoveWhere(x => x.Name == name) > 0;

        public Racer GetOldestRacer()
            => data.OrderByDescending(x => x.Age).FirstOrDefault();

        public Racer GetRacer(string name)
            => data.FirstOrDefault(x => x.Name == name);

        public Racer GetFastestRacer()
            => data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Racers participating at {Name}:");

            foreach (var racer in data)
            {
                output.AppendLine(racer.ToString().TrimEnd());
            }

            return output.ToString().TrimEnd();
        }

    }
}
