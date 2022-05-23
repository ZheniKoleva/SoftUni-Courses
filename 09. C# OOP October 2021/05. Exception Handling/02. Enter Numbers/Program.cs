using System;

namespace _02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            int[] numbers = new int[10];

            for (int i = 0; i < numbers.Length; i++)
            {
                try
                {
                    numbers[i] = ReadNumbers(start, end);                   
                }
                catch (SystemException e)
                {
                    i--;
                    Console.WriteLine(e.Message);
                }
            }

        }

        private static int ReadNumbers(int start, int end)
        {
            int number;
            try
            {
                number = int.Parse(Console.ReadLine()); 
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid number format");
            }
            catch (OverflowException)
            {
                throw new OverflowException("The number is not an integer");
            }

            if (number < start || number > end)
            {
                throw new ArgumentException($"The number should be in the range {start} - {end}");
            }

            return number;
        }
    }
}
