namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {    
        //Task 1 Constructor

        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        //Task 2 Constructor

        public Citizen(string name, int age, string id, string birthdate)            
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get ; private set ; }

        public int Age { get; private set; }

        //Task 2 additional properties

        public string Id { get ; private set ; }

        public string Birthdate { get ; private set ; }
    }
}