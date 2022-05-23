using System;

namespace _01.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = ValidateNumber();

                Console.WriteLine(Math.Sqrt(number));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);               
            }
            finally
            {
                Console.WriteLine("Goodbye");            
            }
        }

        private static int ValidateNumber()
        {
            string message = "Invalid number";

            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                throw new ArgumentException(message);
            }

            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(message);
            }

            return number;
        }
    }
}
