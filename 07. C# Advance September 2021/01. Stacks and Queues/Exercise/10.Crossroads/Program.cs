using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenDuration = int.Parse(Console.ReadLine());
            int windowDuration = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int carsPassed = 0;
            bool hasCrash = false;
            string crashedCar = string.Empty;
            char crashIndx = default;

            string line;

            while (!hasCrash && (line = Console.ReadLine()) != "END")
            {
                if (line != "green")
                {
                    cars.Enqueue(line);
                    continue;
                }

                int currentGreenDuration = greenDuration;

                while (cars.Any() && currentGreenDuration > 0)
                {
                    string currentCar = cars.Dequeue();

                    if (currentCar.Length <= currentGreenDuration)
                    {
                        currentGreenDuration -= currentCar.Length;
                        carsPassed++;
                        continue;
                    }

                    if (currentCar.Length <= currentGreenDuration + windowDuration)
                    {
                        carsPassed++;
                        break;
                    }

                    hasCrash = true;
                    crashIndx = currentCar[currentGreenDuration + windowDuration];
                    crashedCar = currentCar;
                    break;
                }
            }

            Console.WriteLine(hasCrash
                ? "A crash happened!\n" + $"{crashedCar} was hit at {crashIndx}."
                : "Everyone is safe.\n" + $"{carsPassed} total cars passed the crossroads.");
        }
    }
}
