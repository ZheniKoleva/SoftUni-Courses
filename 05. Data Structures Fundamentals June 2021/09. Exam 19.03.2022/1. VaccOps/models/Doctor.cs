namespace VaccTests
{
    public class Doctor
    {
        public Doctor(string name, int popularity)
        {
            this.Name = name;
            this.Popularity = popularity;
        }

        public string Name { get; set; }
        public int Popularity { get; set; }
    }
}
