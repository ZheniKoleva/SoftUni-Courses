using System;
using System.Text;

namespace _07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            //StringBuilder input = new StringBuilder(Console.ReadLine());
            string input = Console.ReadLine();

            int power = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    power += int.Parse(input[i + 1].ToString());
                   // input.Remove(i + 1, 1);
                    input = input.Remove(i + 1, 1);
                    power--;
                }
                else if (power > 0 && input[i] != '>')
                {
                    //input.Remove(i, 1);
                    input = input.Remove(i, 1);
                    power--;
                    i--;
                }
            }

            Console.WriteLine(input);
        }
    }
}
