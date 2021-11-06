namespace _03.Telephony
{
    using System; 

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = ReadData();
            string[] webSites = ReadData();

            ICallable phone = new StationaryPhone();
            IBrowsable smartPhone = new Smartphone();
            
            foreach (var number in numbers)
            {
                Console.WriteLine(number.Length == 7 
                    ? phone.Call(number)
                    : smartPhone.Call(number));
            }

            foreach (var site in webSites)
            {
                Console.WriteLine(smartPhone.Browse(site));
            }
           
        }      

        public static string[] ReadData()
            => Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }
}
