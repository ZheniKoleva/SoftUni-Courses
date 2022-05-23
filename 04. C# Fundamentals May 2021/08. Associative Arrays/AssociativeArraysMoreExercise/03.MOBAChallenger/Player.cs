using System;
using System.Collections.Generic;
using System.Text;

namespace _03.MOBAChallenger
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
            this.SkillsHave = new List<Skill>();           
        }


        public string Name { get; set; }

        public List<Skill> SkillsHave { get; set; }

    }
}
