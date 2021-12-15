namespace SoftUniParking
{
    using System.Collections.Generic;

    public class Parking
    {
        private Dictionary<string, Car> carsByRegNumber;

        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;            
            this.carsByRegNumber = new Dictionary<string, Car>(capacity);
        }

        public int Count => carsByRegNumber.Count;

        public string AddCar(Car car)
        {
            if (carsByRegNumber.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (carsByRegNumber.Count + 1 > capacity)
            {
                return "Parking is full!";
            }

            carsByRegNumber.Add(car.RegistrationNumber, car);

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public Car GetCar(string registrationNumber)
            => carsByRegNumber[registrationNumber];

        public string RemoveCar(string registrationNumber)
        {
            if (!carsByRegNumber.ContainsKey(registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }

            carsByRegNumber.Remove(registrationNumber);

            return $"Successfully removed {registrationNumber}";
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                carsByRegNumber.Remove(registrationNumber);
            }
        }
    }
}