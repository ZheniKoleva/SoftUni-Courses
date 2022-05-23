using System.Collections.Generic;

namespace _01.Ranking
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


        public override string ToString()
        {
               return $"# {Name} -> {Points}"; 
        }

    }
}