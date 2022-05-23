using System;

namespace _06.ValidPerson
{
    public class Person
    {
        private const int MinAge = 0;

        private const int MaxAge = 120;

        private string firstName;

        private string lastName;

        private int age;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName 
        { 
            get => firstName;
            private set
            {
                ValidateName(value, nameof(FirstName));

                lastName = value;
            }
        }

        public string LastName 
        { 
            get => lastName;
            private set
            {
                ValidateName(value, nameof(LastName));

                lastName = value;            
            }
        }       

        public int Age 
        { 
            get => age;
            private set
            {
                ValidateAge(value);

                age = value;
            }
        }

        private void ValidateAge(int value)
        {
            if (value < MinAge || value > MaxAge)
            {
                throw new ArgumentOutOfRangeException($"The age should be in the range [{MinAge} - {MaxAge}]" +
                    $"{Environment.NewLine}Parameter name: {value}");
            }
        }

        private void ValidateName(string value, string parameter)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException($"The {parameter} can not be null or empty." +
                    $"{Environment.NewLine}Parameter name: {value}");
            }
        }
    }
}
