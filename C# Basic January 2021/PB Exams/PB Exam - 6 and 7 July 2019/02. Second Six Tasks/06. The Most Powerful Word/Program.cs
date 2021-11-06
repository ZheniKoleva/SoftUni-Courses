using System;

namespace _06.TheMostPowerfulWord
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double sumMax = double.MinValue;
            string powerfulWord = string.Empty;

            while (input!= "End of words")
            {
                double sum = 0.00;
                for (int index = 0; index < input.Length; index++)
                {
                    sum += input[index]; 
                }

                bool isTrue = input[0] == 'a' || input[0] == 'e' || input[0] == 'i' || 
                    input[0] == 'o' || input[0] == 'u' || input[0] == 'y' ||
                        input[0] == 'A' || input[0] == 'E' || input[0] == 'I' ||
                        input[0] == 'O' || input[0] == 'U' || input[0] == 'Y';

                if (isTrue)
                {
                    sum *= input.Length;
                }
                else
                {
                    sum /= input.Length;
                    sum = Math.Floor(sum);
                }

                if (sum > sumMax)
                {
                    sumMax = sum;
                    powerfulWord = input;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The most powerful word is {powerfulWord} - {sumMax}");
        }
    }
}
