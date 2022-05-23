using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private Dictionary<string, Car> data;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new Dictionary<string, Car>(capacity);
        }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Car car)
        {
            string key = $"{car.Manufacturer}_{car.Model}";

            if (!data.ContainsKey(key) && Count + 1 <= Capacity)
            {
                data.Add(key, car);
            }        
        }

        public bool Remove(string manufacturer, string model)
            => data.Remove($"{manufacturer}_{model}");

        public Car GetLatestCar()
            => data.Values.OrderByDescending(x => x.Year).FirstOrDefault();

        public Car GetCar(string manufacturer, string model)
            => data.ContainsKey($"{manufacturer}_{model}") ? data[$"{manufacturer}_{model}"] : null;

        public string GetStatistics()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"The cars are parked in {Type}:");

            foreach (var (_, car) in data)
            {
                output.AppendLine(car.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
