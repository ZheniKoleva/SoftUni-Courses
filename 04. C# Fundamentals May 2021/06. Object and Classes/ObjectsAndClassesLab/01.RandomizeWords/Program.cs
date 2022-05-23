using System;

namespace _01.RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            ShuffleWords(words);

            Console.WriteLine(string.Join(Environment.NewLine, words));
          
        }

        private static void ShuffleWords(string[] array)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                int newIndx = random.Next(0, array.Length);

                string temp = array[i];
                array[i] = array[newIndx];
                array[newIndx] = temp;
            }
        }
    }   
}
