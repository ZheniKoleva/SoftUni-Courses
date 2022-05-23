using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private Dictionary<string, Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new Dictionary<string, Student>(capacity);
        }

        public int Capacity { get; set; }

        public int Count => students.Count;

        public string RegisterStudent(Student student)
        {
            string key = $"{student.FirstName}_{student.LastName}";

            if (!students.ContainsKey(key) && Count + 1 <= Capacity)
            {
                students.Add(key, student);

                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            string key = $"{firstName}_{lastName}";

            return students.Remove(key)
                 ? $"Dismissed student {firstName} {lastName}"
                 : "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> filtered = students.Values
                .Where(x => x.Subject == subject)
                .ToList();

            if (filtered.Count == 0)
            {
                return "No students enrolled for the subject";
            }

            StringBuilder output = new StringBuilder();
            output.AppendLine($"Subject: {subject}");
            output.AppendLine("Students:");

            foreach (var student in filtered)
            {
                output.AppendLine($"{student.FirstName} {student.LastName}");
            }

            return output.ToString().TrimEnd();        
        }

        public int GetStudentsCount() => Count;

        public Student GetStudent(string firstName, string lastName)
        { 
            string key = $"{firstName}_{lastName}";

            return students[key];
        }
    }
}
