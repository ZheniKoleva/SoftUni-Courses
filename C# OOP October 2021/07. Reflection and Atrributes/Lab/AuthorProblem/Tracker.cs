using System;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var flags = BindingFlags.Static | BindingFlags.NonPublic
                        | BindingFlags.Public | BindingFlags.Instance;

            Type type = typeof(StartUp);

            MethodInfo[] methods = type.GetMethods(flags);

            foreach (var method in methods)
            {
                var attributes = method.GetCustomAttributes(typeof(AuthorAttribute), true);                    

                foreach (AuthorAttribute attribute in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                }
                
            }            
        }
    }
}
