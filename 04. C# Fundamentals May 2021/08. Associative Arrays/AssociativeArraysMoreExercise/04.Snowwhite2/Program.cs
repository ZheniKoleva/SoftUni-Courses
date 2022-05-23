using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Snowwhite2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Dwarf>> dwarfsByHat = new Dictionary<string, List<Dwarf>>();

            string line = Console.ReadLine();

            while (line != "Once upon a time")
            {
                Dwarf currentDwarf = CreateDwarf(line);

                string hatColor = currentDwarf.HatColor;                

                if (!dwarfsByHat.ContainsKey(hatColor))
                {
                    dwarfsByHat.Add(hatColor, new List<Dwarf>() { currentDwarf });
                    line = Console.ReadLine();
                    continue;
                }

                Dwarf searched = dwarfsByHat[hatColor].FirstOrDefault(x => x.Name == currentDwarf.Name);

                if (searched == null)
                {
                    dwarfsByHat[hatColor].Add(currentDwarf);
                }
                else if (currentDwarf.Physics > searched.Physics)
                {
                    searched.Physics = currentDwarf.Physics;
                }  

                line = Console.ReadLine();
            }

            Dictionary<string, int> ordered = new Dictionary<string, int>();

            //List<Dwarf> ordered = new List<Dwarf>();

            foreach (var hat in dwarfsByHat.OrderByDescending(x => x.Value.Count)) // червени, зелени
            {  
                foreach (var dwarf in hat.Value.OrderByDescending(x => x.Physics)) // червените по точки
                {
                    ordered.Add($"({dwarf.HatColor}) {dwarf.Name}", dwarf.Physics);
                    //ordered.Add(dwarf);
                    
                }
            }

            //ordered = ordered.OrderByDescending(x => x.Physics).ToList();

            //Console.WriteLine(string.Join(Environment.NewLine, ordered));

            foreach (var dwarf in ordered.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{dwarf.Key} <-> {dwarf.Value}");
            }

        }

        private static Dwarf CreateDwarf(string line)
        {
            string[] parts = line
                    .Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);

            string dwarfName = parts[0];
            string hatColor = parts[1];
            int dwarfPhysics = int.Parse(parts[2]);

            return new Dwarf(dwarfName, hatColor, dwarfPhysics);
        }
    }

    //class Dwarf
    //{
    //    public string Name { get; set; }

    //    public string HatColor { get; set; }

    //    public int Physics { get; set; }

    //    public Dwarf(string name, string hat, int physics)
    //    {
    //        Name = name;
    //        HatColor = hat;
    //        Physics = physics;
    //    }

    //    public override string ToString()
    //    {
    //        return $"({HatColor}) {Name} <-> {Physics}";
    //    }

    //}
}
