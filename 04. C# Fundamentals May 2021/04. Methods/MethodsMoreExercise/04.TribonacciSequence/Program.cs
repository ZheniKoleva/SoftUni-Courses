using System;

namespace _04.TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintTribonacciSequence(number);
        }

        private static void PrintTribonacciSequence(int number)
        {
            int[] sequence = GetSequence(number);

            Console.WriteLine(string.Join(' ', sequence));
        }

        private static int[] GetSequence(int number)
        {
            int[] sequence = new int[number];
            
            for (int i = 0; i < sequence.Length; i++)
            {
                if (i == 0 || i == 1)
                {
                    sequence[i] = 1;
                }
                else if (i == 2)
                {
                    sequence[i] = 2;
                }
                else
                {
                    sequence[i] = sequence[i - 1] + sequence[i - 2] + sequence[i - 3];
                }
            }

            return sequence;
            
            //if (number <= 2)
            //{
            //    return 1;
            //}
            //else if (number == 3)
            //{
            //    return 2;                
            //}           
            //else
            //{
            //    return GetSequence(number - 1) + GetSequence(number - 2) + GetSequence(number - 3);               
            //}
        }
    }
}
