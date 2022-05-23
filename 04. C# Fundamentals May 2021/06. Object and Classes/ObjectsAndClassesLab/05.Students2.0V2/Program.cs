using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Students2._0V2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentsList = new List<Student>();

            string line = Console.ReadLine();

            while (line != "end")
            {
                Student current = CreateStudent(line);

                if (IsStudentExist(studentsList, current))
                {
                    EditStudentData(studentsList, current);
                }
                else
                {
                    studentsList.Add(current);
                }

                line = Console.ReadLine();
            }

            string town = Console.ReadLine();

            PrintStudents(studentsList, town);
        }

        private static void PrintStudents(List<Student> studentsList, string town)
        {
            List<Student> filtered = studentsList
                .Where(s => s.HomeTown == town)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, filtered));
        }

        private static Student CreateStudent(string line)
        {
            string[] data = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string firstName = data[0];
            string lastName = data[1];
            int age = int.Parse(data[2]);
            string homeTown = data[3];

            return new Student(firstName, lastName, age, homeTown);
        }

        private static void EditStudentData(List<Student> students, Student current)
        {
            Student studentToEdit = students.First(x => x.FirstName == current.FirstName && x.LastName == current.LastName);
            studentToEdit.Age = current.Age;
            studentToEdit.HomeTown = current.HomeTown;
        }

        private static bool IsStudentExist(List<Student> students, Student current)
        {
            return students.Any(x => x.FirstName == current.FirstName && x.LastName == current.LastName);
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

        public string LastName { get; set; }

        public int Age { get; set; }

        public string HomeTown { get; set; }


        public override string ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old.";
        }
    }
}
