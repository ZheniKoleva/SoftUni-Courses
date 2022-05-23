namespace _02.Judge
{
    public class Contest
    {
        public Contest(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }

        public string Name { get; private set; }

        public int Points { get; set; }

    }
}