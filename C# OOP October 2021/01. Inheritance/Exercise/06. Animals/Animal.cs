namespace Animals
{
    using System;
    using System.Text;

    public abstract class Animal
    {
        private string name;

        private int age;

        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name 
        { 
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;            
            }
        }

        public int Age 
        { 
            get => this.age;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;            
            }
        }

        public string Gender 
        {
            get => this.gender;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || (value != "Male" && value != "Female"))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(this.GetType().Name)
                  .AppendLine($"{Name} {Age} {Gender}")
                  .Append($"{ProduceSound()}");

            return output.ToString().TrimEnd();
        }
    }

}
