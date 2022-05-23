using System;

namespace _10.LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char letter = char.Parse(Console.ReadLine());
            //string output = char.IsLower(letter) ? "lower-case" : "upper-case";

            //Console.WriteLine(output);

            if (char.IsLower(letter))
            {
                Console.WriteLine("lower-case");
            }
            else
            {
                Console.WriteLine("upper-case");
            }
        }
    }
}
