using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DragonArmy
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Dragon>> dragonTypes = new Dictionary<string, List<Dragon>>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] dragonData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = dragonData[0];

                Dragon currentDragon = CreateDragon(dragonData[1..]);                

                if (!dragonTypes.ContainsKey(type))
                {
                    dragonTypes.Add(type, new List<Dragon>() { currentDragon });
                    continue;
                }

                if (!dragonTypes[type].Any(a => a.Name == currentDragon.Name))
                {
                    dragonTypes[type].Add(currentDragon);
                }
                else
                {
                    Dragon exist = dragonTypes[type].FirstOrDefault(a => a.Name == currentDragon.Name);
                    dragonTypes[type].Remove(exist);
                    dragonTypes[type].Add(currentDragon);
                }

            }

            PrintDragons(dragonTypes);

        }

        private static Dragon CreateDragon(string[] dragonData)
        {
            string dragonName = dragonData[0];
            int damage = int.TryParse(dragonData[1], out damage) ? damage : 45;
            int health = int.TryParse(dragonData[2], out health) ? health : 250;
            int armor = int.TryParse(dragonData[3], out armor) ? armor : 10;

            return new Dragon(dragonName, damage, health, armor);
        }

        private static void PrintDragons(Dictionary<string, List<Dragon>> dragonTypes)
        {
            foreach (var type in dragonTypes)
            {
                double avgDamage = type.Value.Average(a => a.Damage);
                double avgHealth = type.Value.Average(a => a.Health);
                double avgArmor = type.Value.Average(a => a.Armor);

                Console.WriteLine($"{type.Key}::({avgDamage:f2}/{avgHealth:f2}/{avgArmor:f2})");

                foreach (var dragon in type.Value.OrderBy(a => a.Name))
                {
                    Console.WriteLine(dragon);
                }
            }
        }
    }

    class Dragon
    {
        private int damage = 45;

        private int health = 250;

        private int armor = 10;

        public Dragon(string name, int damage, int health, int armor)
        {
            Name = name;
            Damage = damage;
            Health = health;
            Armor = armor;
        }
        public string Name { get; set; }

        public int Damage { get; private set; }

        public int Health { get; private set; }

        public int Armor { get; private set; }


        public override string ToString()
        {
            return $"-{Name} -> damage: {Damage}, health: {Health}, armor: {Armor}";
        }

    }

}
