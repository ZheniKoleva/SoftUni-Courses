using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CompanyRoster2
{
    class Program
    {
        static void Main(string[] args)
        {
            int employeesCount = int.Parse(Console.ReadLine());

            Dictionary<string, List<Employee>> employees = new Dictionary<string, List<Employee>>();
            
            for(int i = 0; i < employeesCount; i++)
            {
                Employee current = CreateEmployee();

                string department = current.Department;

                if (!employees.ContainsKey(department))
                {
                    employees.Add(department, new List<Employee>());                   
                }

                employees[department].Add(current);                
            }

            string bestDepartment = employees
                 .OrderByDescending(d => d.Value.Average(e => e.Salary))
                 .First().Key;

            List<Employee> departmentMax = employees[bestDepartment]
                .OrderByDescending(e => e.Salary)
                .ThenBy(e => e.Name)
                .ToList();

            Console.WriteLine($"Highest Average Salary: {bestDepartment}");
            Console.WriteLine(string.Join(Environment.NewLine, departmentMax));           
        }

        private static Employee CreateEmployee()
        {
            string[] employeeData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string employeeName = employeeData[0];
            double salary = double.Parse(employeeData[1]);
            string department = employeeData[2];

            return new Employee(employeeName, salary, department);
        }
    }

    public class Employee
    {
        private string name;

        private double salary;

        private string department;

        public Employee(string name, double salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }

        public string Name { get; set; }

        public double Salary { get; set; }

        public string Department { get; set; }

        public override string ToString()
        {
            return $"{Name} {Salary:f2}";
        }
    }
}
