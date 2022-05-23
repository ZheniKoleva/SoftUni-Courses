using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            string healthPattern = @"[^\d\+\-\*\/\.]";
            string damagePattern = @"([\+\-]*\d+[\.\d+]*)";
            string operatorPattern = @"[\*\/]";

            List<Demon> result = new List<Demon>();

            string[] demonsList = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);           

            foreach (var demon in demonsList)
            {
                int healthPoints = Regex.Matches(demon, healthPattern)
                    .Cast<Match>()
                    .Select(x => (int)char.Parse(x.Value))
                    .Sum();

                double damagePoints = Regex.Matches(demon, damagePattern)
                    .Cast<Match>()
                    .Select(x => double.Parse(x.Value))
                    .Sum();

                char[] operators = Regex.Matches(demon, operatorPattern)
                    .Cast<Match>()
                    .Select(x => char.Parse(x.Value))
                    .ToArray();

                foreach (var item in operators)
                {
                    damagePoints = item.Equals('*') ? damagePoints * 2 : damagePoints / 2;
                }

                result.Add(new Demon(demon, healthPoints, damagePoints));

            }

            Console.WriteLine(string.Join(Environment.NewLine, result.OrderBy(x => x.Name)));

        }
    }

    public class Demon 
    {
        public Demon(string name, int health, double damage)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
        }

        public string Name { get; set; }

        public int Health { get; set; }

        public double Damage { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Health} health, {Damage:f2} damage";
        }

    }
}
