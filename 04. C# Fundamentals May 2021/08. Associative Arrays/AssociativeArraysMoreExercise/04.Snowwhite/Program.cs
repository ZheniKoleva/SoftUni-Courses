using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, uint>> dwarfsByHatColor = new Dictionary<string, Dictionary<string, uint>>();

            string input = Console.ReadLine();

            while (input != "Once upon a time")
            {
                string[] parts = input.Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);

                string dwarfName = parts[0];
                string hatColor = parts[1];
                uint dwarfPhysic = uint.Parse(parts[2]);

                if (!dwarfsByHatColor.ContainsKey(hatColor))
                {
                    dwarfsByHatColor.Add(hatColor, new Dictionary<string, uint>());
                }

                if (!dwarfsByHatColor[hatColor].ContainsKey(dwarfName))
                {
                    dwarfsByHatColor[hatColor].Add(dwarfName, dwarfPhysic);
                }

                if (dwarfsByHatColor[hatColor][dwarfName] < dwarfPhysic)
                {
                    dwarfsByHatColor[hatColor][dwarfName] = dwarfPhysic;
                }

                input = Console.ReadLine();
            }

            Dictionary<string, uint> result = new Dictionary<string, uint>();

            foreach (var hatColor in dwarfsByHatColor.OrderByDescending(a => a.Value.Count))
            {
                foreach (var dwarf in hatColor.Value)
                {
                    result.Add($"({hatColor.Key}) {dwarf.Key}", dwarf.Value);
                }
            }

            foreach (var dwarf in result.OrderByDescending(a => a.Value))
            {
                Console.WriteLine($"{dwarf.Key} <-> {dwarf.Value}");
            }

        }

    }
}
