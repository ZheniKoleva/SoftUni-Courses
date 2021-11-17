using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result;

            //Task 01. Stealer           
            result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");           
            Console.WriteLine(result);

            //Task 02. High Quality Mistakes
            result = spy.AnalyzeAccessModifiers("Stealer.Hacker");
            Console.WriteLine(result);

            //Task 03. Mission Private Impossible
            result = spy.RevealPrivateMethods("Stealer.Hacker");
            Console.WriteLine(result);

            //Task 04. Collector
            result = spy.CollectGettersAndSetters("Stealer.Hacker");
            Console.WriteLine(result);

        }
    }
}
