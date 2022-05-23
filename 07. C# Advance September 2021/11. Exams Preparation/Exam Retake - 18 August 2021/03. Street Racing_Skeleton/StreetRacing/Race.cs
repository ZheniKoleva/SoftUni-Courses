using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new Dictionary<string, Car>(capacity);
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        public int Count => Participants.Count;

        public Dictionary<string, Car> Participants { get; set; }

        public void Add(Car car)
        {
            if (!IsCarExists(car.LicensePlate) 
                && Count + 1 <= Capacity 
                && car.HorsePower <= MaxHorsePower )
            {
               Participants.Add(car.LicensePlate, car);
            }        
        }

        public bool Remove(string licensePlate) => Participants.Remove(licensePlate);

        public Car FindParticipant(string licensePlate)
            => IsCarExists(licensePlate) ? Participants[licensePlate] : null;     

        public Car GetMostPowerfulCar() 
            => Participants.Values.OrderByDescending(x => x.HorsePower).FirstOrDefault();
       

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach (var car in Participants.Values)
            {
                output.AppendLine(car.ToString().TrimEnd());
            }

            return output.ToString();        
        }

        private bool IsCarExists(string licensePlate) 
            => Participants.ContainsKey(licensePlate);
    }
}