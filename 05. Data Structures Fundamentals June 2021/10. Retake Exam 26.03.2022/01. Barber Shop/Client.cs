using System;
namespace BarberShop
{
    public class Client
    {
        public Client(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Barber Barber { get; set; }
    }
}
