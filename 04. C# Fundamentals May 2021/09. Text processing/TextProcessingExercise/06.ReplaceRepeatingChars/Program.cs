using System;
using System.Text;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());
            //string input = Console.ReadLine();

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == input[i - 1])
                {
                    input.Remove(i - 1, 1);
                   //input = input.Remove(i - 1, 1);
                    i--;
                } 
            }

            Console.WriteLine(input);
        }
    }
}
