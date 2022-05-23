using System;

namespace _06.ValidPerson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Person 1
            Person firstPerson = new Person("Pesho", "Johnson", 24);

            //Person 2
            try
            {
                Person personWithoutFirstName = new Person(string.Empty, "Peterson", 31);               
            }
            catch (ArgumentNullException ane)
            {                
                Console.WriteLine($"Exception thrown: {ane.ParamName}");
            }
            catch (ArgumentOutOfRangeException aor)
            {
                Console.WriteLine($"Exception thrown: {aor.ParamName}");
            }
           
            //Person 3
            try
            {
                Person personWithoutLastName = new Person("Jordon", string.Empty, 25);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"Exception thrown: {ane.ParamName}");
            }
            catch (ArgumentOutOfRangeException aor)
            {
                Console.WriteLine($"Exception thrown: {aor.ParamName}");
            }  

            //Person 4
            try
            {
                Person personWithNegativeAge = new Person("Peter", "Miller", -20);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"Exception thrown: {ane.ParamName}");
            }
            catch (ArgumentOutOfRangeException aor)
            {
                Console.WriteLine($"Exception thrown: {aor.ParamName}");
            }

            //Person 5
            try
            {
                Person personWithTooBigAge = new Person("Sam", "Bundy", 125);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"Exception thrown: {ane.ParamName}");
            }
            catch (ArgumentOutOfRangeException aor)
            {
                Console.WriteLine($"Exception thrown: {aor.ParamName}");
            }          

        }
    }
}
