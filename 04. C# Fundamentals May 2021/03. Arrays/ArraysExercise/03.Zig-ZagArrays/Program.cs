using System;

namespace _03.Zig_ZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            string[] first = new string[lines];
            string[] second = new string[lines];

            for (int i = 0; i < lines; i++)
            {
                string[] current = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (i % 2 == 0)
                {
                    first[i] = current[0];
                    second[i] = current[1];
                }
                else
                {
                    first[i] = current[1];
                    second[i] = current[0];
                }

            }

            Console.WriteLine(string.Join(' ', first));
            Console.WriteLine(string.Join(' ', second));
        }
    }
}
