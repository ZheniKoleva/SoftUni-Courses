﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryOpenning
{
    public class Employee
    {
        public Employee(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Country { get; set; }

        public override string ToString() => $"Employee: {Name}, {Age} ({Country})";

    }
}
