using System;
using System.Text;

namespace _04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder result = new StringBuilder();

            foreach (var item in input)
            {
                result.Append((char)(item + 3));
            }    
           
            Console.WriteLine(result);
        }
    }
}
