using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> citizens = new List<IIdentifiable>();

            string citizen = Console.ReadLine();

            while (citizen != "End")
            {
                EnteredCitizens(citizens, citizen);

                citizen = Console.ReadLine();
            }

            string rebellionsIdEnd = Console.ReadLine();
            var rebelions = citizens
                .Where(x => x.Id.EndsWith(rebellionsIdEnd))
                .Select(x => x.Id);

            Console.WriteLine(string.Join(Environment.NewLine, rebelions));; 
        }

        private static void EnteredCitizens(List<IIdentifiable> citizens, string citizen)
        {
            string[] citizenData = citizen
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (citizenData.Length == 2)
            {
                string robotName = citizenData[0];
                string id = citizenData[1];

                citizens.Add(new Robot(robotName, id));
            }
            else
            {
                string citizenName = citizenData[0];
                int age = int.Parse(citizenData[1]);
                string id = citizenData[2];

                citizens.Add(new Citizen(citizenName, age, id));
            }
        }
    }
}
