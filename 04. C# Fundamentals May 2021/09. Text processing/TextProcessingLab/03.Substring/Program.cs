using System;
using System.Text;


namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string itemToremove = Console.ReadLine().ToLower();
            StringBuilder input = new StringBuilder(Console.ReadLine());

            while (input.ToString().Contains(itemToremove))
            {
                input.Replace(itemToremove, "");
            }

            Console.WriteLine(input);
        }
    }
}
