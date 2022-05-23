using System;
using System.Text;

namespace _07.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int repeatTimes = int.Parse(Console.ReadLine());

            string output = RepeatString(input, repeatTimes);
            Console.WriteLine(output);
        }

        private static string RepeatString(string input, int repeatTimes)
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < repeatTimes; i++)
            {
                output.Append(input);
            }

            return output.ToString();
        }
    }
}
