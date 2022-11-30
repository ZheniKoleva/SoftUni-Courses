using System;
namespace VaccTests
{
    public class Patient
    {
        public Patient(string name, int height, int age, string town)
        {
            this.Name = name;
            this.Height = height;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }
    }
}
