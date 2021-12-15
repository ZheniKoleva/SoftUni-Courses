using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());
            List<Person> people = FillPerson(linesCount);

            string condition = Console.ReadLine();
            int filterAge = int.Parse(Console.ReadLine());

           Func<Person, bool> filter = condition.Equals("younger") 
                ? filter = x => x.Age < filterAge
                : filter = x => x.Age >= filterAge;           

            var result = people.Where(filter);

            string printFormat = Console.ReadLine();

            Func<Person, string> formatFilter = printFormat.Equals("name")
                ? formatFilter = x => x.Name
                : printFormat.Equals("age") 
                ? formatFilter = x => x.Age.ToString()
                : formatFilter = x => $"{x.Name} - {x.Age}";

            Console.WriteLine(string.Join(Environment.NewLine, result.Select(formatFilter))); 
        }      

        private static List<Person> FillPerson(int linesCount)
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < linesCount; i++)
            {
                string[] personData = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = personData[0];
                int age = int.Parse(personData[1]);

                people.Add(new Person(name, age));
            }

            return people;
        }
    }

    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

    }
}
