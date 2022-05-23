namespace _03.Telephony
{    
    using System.Linq;

    public class Smartphone : IBrowsable
    {
        public string Browse(string site)
            => site.Any(x => char.IsDigit(x)) ? "Invalid URL!" : $"Browsing: {site}!"; 

        public string Call(string number)
            => !number.All(x => char.IsDigit(x)) ? "Invalid number!" : $"Calling... {number}";      
        
    }
}
