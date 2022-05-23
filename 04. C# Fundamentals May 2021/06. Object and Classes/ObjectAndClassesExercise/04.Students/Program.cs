using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < studentsCount; i++)
            {
                Student current = ReadStudent();
                students.Add(current);
            }

            students = students.OrderByDescending(s => s.Grade).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, students));
        }

        private static Student ReadStudent()
        {
            string[] parts = Console.ReadLine()
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string firstName = parts[0];
            string lastName = parts[1];
            double grade = double.Parse(parts[2]);

            Student current = new Student(firstName, lastName, grade);

            return current;            
        }
    }

    public class Student
    {
        private string firstName;

        private string lastName;

        private double grade;

        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }


        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }

    }
}
