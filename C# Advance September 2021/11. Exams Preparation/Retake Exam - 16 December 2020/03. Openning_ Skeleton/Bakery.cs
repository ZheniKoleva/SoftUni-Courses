using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private HashSet<Employee> data;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new HashSet<Employee>(capacity);
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Employee employee)
        {
            if (Count + 1 <= Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name) 
            => data.RemoveWhere(x => x.Name == name) > 0;

        public Employee GetOldestEmployee()
            => data.OrderByDescending(x => x.Age).FirstOrDefault();

        public Employee GetEmployee(string name)
            => data.FirstOrDefault(x => x.Name == name);

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var employee in data)
            {
                output.AppendLine(employee.ToString().TrimEnd());
            }

            return output.ToString().TrimEnd();
        }

    }
}
