using System.Linq;

namespace _07.CustomException
{
    public class Student
    {
        private string name;

        private string email;

        public Student(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name
        {
            get => name;
            private set
            {
                ValidateName(value);

                name = value;
            }
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        private void ValidateName(string value)
        {
            if (!value.All(l => char.IsDigit(l)))
            {
                throw new InvalidPersonNameException();
            }
        }

    }
}