namespace ValidationAttributes
{
    public class Person
    {
        private const int MIN_AGE = 12;

        private const int MAX_AGE = 90;
        public Person(string fullName, int age)
        {
            
            FullName = fullName;
            Age = age;           
        }

        [MyRequired]
        public string FullName { get; }

        [MyRange(MIN_AGE, MAX_AGE)]
        public int Age { get; }
    }
}