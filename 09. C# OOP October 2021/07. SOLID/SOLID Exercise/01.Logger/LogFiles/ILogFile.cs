namespace _01.Logger.LogFiles
{
   public interface ILogFile
    {
        public int Size { get; }

        public void Write(string message);

    }
}
