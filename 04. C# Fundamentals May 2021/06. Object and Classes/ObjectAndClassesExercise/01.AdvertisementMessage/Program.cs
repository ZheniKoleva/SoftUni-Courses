using System;

namespace _01.AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases =
            {   "Excellent product.",
                 "Such a great product.",
                 "I always use that product.",
                 "Best product of its category.",
                 "Exceptional product.",
                 "I can’t live without this product."
            };

            string[] events =
            {   "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int messageCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < messageCount; i++)
            {
                string phrase = GetRandomMessage(phrases);
                string eventNew = GetRandomMessage(events);
                string author = GetRandomMessage(authors);
                string city = GetRandomMessage(cities);

                Console.WriteLine($"{phrase} {eventNew} {author} - {city}");
            }
        }       

        private static string GetRandomMessage(string[] phrases)
        {
           Random randomIndx = new Random();           
            
           int newIndx = randomIndx.Next(0, phrases.Length);

           return phrases[newIndx];
        }
    }
}
