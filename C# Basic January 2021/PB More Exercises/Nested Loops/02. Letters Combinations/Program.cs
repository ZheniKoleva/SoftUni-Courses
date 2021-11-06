using System;

namespace _02.LettersCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char exception = char.Parse(Console.ReadLine());

            int counter = 0;

            for (char firstLetter = start; firstLetter <= end; firstLetter++)
            {
                for (char secondLetter = start; secondLetter <= end; secondLetter++)
                {
                    for (char thirdLetter = start; thirdLetter <= end; thirdLetter++)
                    {
                        if (thirdLetter == exception || secondLetter == exception || firstLetter == exception)
                        {
                            continue;
                        }
                        counter++;                        
                        Console.Write($"{firstLetter}{secondLetter}{thirdLetter} ");
                    }
                }
            }
            Console.Write(counter);
        }
    }
}
