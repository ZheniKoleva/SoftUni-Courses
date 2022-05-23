using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            int employeesCount = int.Parse(Console.ReadLine());

            Dictionary<string, List<Employee>> employees = new Dictionary<string, List<Employee>>();
           //Dictionary<string, List<double>> departmentsBySalary = new Dictionary<string, List<double>>();
            Dictionary<string, double> departmentsBySalary = new Dictionary<string, double>();


            for (int i = 0; i < employeesCount; i++)
            {
                Employee current = CreateEmployee();

                string department = current.Department;

                if (!employees.ContainsKey(department))
                {
                    employees.Add(department, new List<Employee>());
                    departmentsBySalary.Add(department, 0.0);
                   //departmentsBySalary.Add(department, new List<double>());
                }

                employees[department].Add(current);
                departmentsBySalary[department] += current.Salary;
                //departmentsBySalary[department].Add(current.Salary);
            }

            string departmentMaxAvgSalary = GetDepartment(employees);

            List<Employee> departmentMax = employees[departmentMaxAvgSalary]
                .OrderByDescending(e => e.Salary)
                .ThenBy(e => e.Name)
                .ToList();

            Console.WriteLine($"Highest Average Salary: {departmentMaxAvgSalary}");
            Console.WriteLine(string.Join(Environment.NewLine, departmentMax));
           
        }

        private static string GetDepartment(Dictionary<string, List<Employee>> employees)
        {
            double maxAvgSalary = 0.0;
            string departmentMaxSalary = string.Empty;

            foreach (var item in employees)
            {
                string currentdepartment = item.Key;
                double avgSalary = item.Value.Average(e => e.Salary);

                if (avgSalary > maxAvgSalary)
                {
                    maxAvgSalary = avgSalary;
                    departmentMaxSalary = currentdepartment;
                }
            }

            return departmentMaxSalary;
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
