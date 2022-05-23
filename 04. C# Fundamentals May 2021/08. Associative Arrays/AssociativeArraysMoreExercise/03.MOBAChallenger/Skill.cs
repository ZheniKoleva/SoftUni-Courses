using System;
using System.Collections.Generic;
using System.Text;

namespace _03.MOBAChallenger
{
    public class Skill
    {
        public Skill(string position, int skillPoints)
        {
            this.Position = position;
            this.SkillPoints = skillPoints;
        }

        public string Position { get; set; }

        public int SkillPoints { get; set; }

        public override string ToString()
        {
            return $"- {Position} <::> {SkillPoints}";
        }

    }
}
