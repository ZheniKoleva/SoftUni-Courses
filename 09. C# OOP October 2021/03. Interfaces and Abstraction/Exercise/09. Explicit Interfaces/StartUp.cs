using System;

namespace _09.ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] personData = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Citizen citizen = CreateSitizen(personData);

                IPerson citizenAsPerson = citizen;
                IResident citizenAsResident = citizen;

                Console.WriteLine(citizenAsPerson.GetName());
                Console.WriteLine(citizenAsResident.GetName());

                line = Console.ReadLine();
            }
        }

        private static Citizen CreateSitizen(string[] personData)
        {
            string name = personData[0];
            string country = personData[1];
            int age = int.Parse(personData[2]);

            return new Citizen(name, country, age);
        }
    }
}
