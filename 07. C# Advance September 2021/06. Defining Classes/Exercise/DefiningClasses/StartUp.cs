using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < linesCount; i++)
            {
                string[] personData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = personData[0];
                int age = int.Parse(personData[1]);

                people.Add(new Person(name, age));
            }

            Predicate<Person> filterByAge = person => person.Age > 30;

            var filtered = people.Where(x => filterByAge(x)).OrderBy(x => x.Name);

            Console.WriteLine(string.Join(Environment.NewLine, filtered));
        }
    }
}
