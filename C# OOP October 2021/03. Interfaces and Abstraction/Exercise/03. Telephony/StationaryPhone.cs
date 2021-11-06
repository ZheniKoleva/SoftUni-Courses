namespace _03.Telephony
{
    using System.Linq;

    public class StationaryPhone : ICallable
    {
        public string Call(string number) 
            => !number.All(x => char.IsDigit(x)) ? "Invalid number!" : $"Dialing... {number}";        
    }
}
