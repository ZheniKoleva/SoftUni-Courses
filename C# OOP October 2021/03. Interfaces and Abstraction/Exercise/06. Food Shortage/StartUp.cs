using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            Dictionary<string, IBuyer> people = AddBuyers(peopleCount);

            string customerName = Console.ReadLine();

            while (customerName != "End")
            {
                if (people.ContainsKey(customerName))
                {
                    people[customerName].BuyFood();
                } 

                customerName = Console.ReadLine();
            }

            Console.WriteLine(people.Values.Sum(x => x.Food));

        }
        private static Dictionary<string, IBuyer> AddBuyers(int peopleCount)
        {
            Dictionary<string, IBuyer> people = new Dictionary<string, IBuyer>();

            for (int i = 0; i < peopleCount; i++)
            {
                string[] buyerData = ReadData();
                string name = buyerData[0];
                int age = int.Parse(buyerData[1]);

                if (buyerData.Length == 3)
                {
                    string group = buyerData[2];
                    people.Add(name, new Rebel(name, age, group));
                }
                else
                {
                    string id = buyerData[2];
                    string birthday = buyerData[3];
                    people.Add(name, new Citizen(name, age, id, birthday));
                }
            }
           

            return people;
        }

        private static string[] ReadData()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
