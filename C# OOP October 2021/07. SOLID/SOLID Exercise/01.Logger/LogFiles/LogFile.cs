using System.Text;
using System.Linq;

namespace _01.Logger.LogFiles
{
    public class LogFile : ILogFile
    {
        private StringBuilder result;

        public LogFile()
        {
            result = new StringBuilder();
        }

        public int Size 
            => result.ToString()
                     .Where(x => char.IsLetter(x))
                     .Sum(x => x);
       
        public void Write(string message)
            => result.Append(message);         
    }
}
