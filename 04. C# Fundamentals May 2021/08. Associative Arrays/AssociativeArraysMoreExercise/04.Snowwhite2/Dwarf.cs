using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Snowwhite2
{
   public class Dwarf
    {
        public string Name { get; set; }

        public string HatColor { get; set; }

        public int Physics { get; set; }

        public Dwarf(string name, string hat, int physics)
        {
            Name = name;
            HatColor = hat;
            Physics = physics;
        }

        public override string ToString()
        {
            return $"({HatColor}) {Name} <-> {Physics}";
        }

    }
}
