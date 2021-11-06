using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> citizens = new List<IBirthable>();

            string citizen = Console.ReadLine();

            while (citizen != "End")
            {
                string[] citizenData = citizen
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (citizenData[0].Equals("Robot"))
                {
                    citizen = Console.ReadLine();
                    continue;
                }

                AddCitizens(citizens, citizenData);

                citizen = Console.ReadLine();
            }

            string searchedYear = Console.ReadLine();
            var filtered = citizens
                .Where(c => c.Birthdate.EndsWith(searchedYear))
                .Select(c => c.Birthdate);

            Console.WriteLine(string.Join(Environment.NewLine, filtered));            
        }

        private static void AddCitizens(List<IBirthable> citizens, string[] citizenData)
        {
            string type = citizenData[0];
            string name = citizenData[1];

            switch (type)
            {
                case "Citizen":
                    int age = int.Parse(citizenData[2]);
                    string id = citizenData[3];
                    string birthday = citizenData[4];
                    
                    citizens.Add(new Citizen(name, age, id, birthday));
                    break;

                case "Pet":
                    birthday = citizenData[2];

                    citizens.Add(new Pet(name, birthday));
                    break;
            }
        }
    }
}
