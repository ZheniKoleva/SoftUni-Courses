namespace _09.ExplicitInterfaces
{
    class Citizen : IResident, IPerson
    {
        public Citizen(string name, string country, int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Country { get; private set; }

        string IResident.GetName() => $"Mr/Ms/Mrs {this.Name}";        

        string IPerson.GetName() => this.Name;      

    }
}
