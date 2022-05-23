using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentsList = ReadStudents();

            string town = Console.ReadLine();

            PrintStudents(studentsList, town);
        }

        private static void PrintStudents(List<Student> studentsList, string town)
        {
            //List<Student> filtered = studentsList
            //    .Where(s => s.HomeTown == town)
            //    .ToList();

            //Console.WriteLine(string.Join(Environment.NewLine, filtered));

            foreach (Student item in studentsList)
            {
                if (town == item.HomeTown)
                {
                    Console.WriteLine(item);
                }
            }

        }

        private static List<Student> ReadStudents()
        {
            List<Student> students = new List<Student>();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] data = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string firstName = data[0];
                string lastName = data[1];
                int age = int.Parse(data[2]);
                string homeTown = data[3];

                students.Add(new Student(firstName, lastName, age, homeTown));

                line = Console.ReadLine();
            }

            return students;
        }
    }

    public class Student 
    {
        private string firstName;

        private string lastName;

        private int age;

        private string homeTown;

        public Student(string firstName, string lastName, int age, string homeTown)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.HomeTown = homeTown;
        }
        public string FirstName { get; set; }

        public string LastName  { get; set; }

        public int Age { get; set; }

        public string HomeTown { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old."; 
        }
    }
}
