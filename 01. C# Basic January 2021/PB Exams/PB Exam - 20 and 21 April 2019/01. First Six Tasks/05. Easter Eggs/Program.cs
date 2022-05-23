using System;

namespace _05.EasterEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int colouredEggsCount = int.Parse(Console.ReadLine());

            int countRed = 0;
            int countOrange = 0;
            int countBlue = 0;
            int countGreen = 0;

            int countMax = int.MinValue;
            string colourEggsMax = string.Empty;

            for (int i = 1; i <= colouredEggsCount; i++)
            {
                string eggColour = Console.ReadLine().ToLower();

                switch (eggColour)
                {
                    case "red":
                        countRed++;
                        if (countRed > countMax)
                        {
                            countMax = countRed;
                            colourEggsMax = eggColour;
                        }
                        break;

                    case "orange":
                        countOrange++;
                        if (countOrange > countMax)
                        {
                            countMax = countOrange;
                            colourEggsMax = eggColour;
                        }
                        break;

                    case "blue":
                        countBlue++;
                        if (countBlue > countMax)
                        {
                            countMax = countBlue;
                            colourEggsMax = eggColour;
                        }
                        break;

                    case "green":
                        countGreen++;
                        if (countGreen > countMax)
                        {
                            countMax = countGreen;
                            colourEggsMax = eggColour;
                        }
                        break;
                }

            }

            Console.WriteLine($"Red eggs: {countRed}");
            Console.WriteLine($"Orange eggs: {countOrange}");
            Console.WriteLine($"Blue eggs: {countBlue}");
            Console.WriteLine($"Green eggs: {countGreen}");
            Console.WriteLine($"Max eggs: {countMax} -> {colourEggsMax}");

        }
    }
}
