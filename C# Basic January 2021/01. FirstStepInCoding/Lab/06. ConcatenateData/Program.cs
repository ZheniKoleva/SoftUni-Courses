using System;

namespace _06._ConcatenateData
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            double age = double.Parse(Console.ReadLine());
            string town = Console.ReadLine();

            Console.WriteLine("You are {0} {1}, a {2}-years old person from {3}.", 
                firstName, lastName, age, town);
        }
    }
}
