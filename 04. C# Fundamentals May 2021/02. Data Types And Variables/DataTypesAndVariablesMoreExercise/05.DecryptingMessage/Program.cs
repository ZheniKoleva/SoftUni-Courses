using System;

namespace _05.DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            byte key = byte.Parse(Console.ReadLine());
            byte lines = byte.Parse(Console.ReadLine());

            string decrypted = string.Empty;

            for (int i = 0; i < lines; i++)
            {
                char current = char.Parse(Console.ReadLine());

                decrypted += (char)(current + key); 
            }

            Console.WriteLine(decrypted);
        }
    }
}
