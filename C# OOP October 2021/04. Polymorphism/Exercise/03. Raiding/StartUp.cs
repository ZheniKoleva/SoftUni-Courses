using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int heroesCount = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();

            while (heroes.Count != heroesCount)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    BaseHero current = HeroCreator.CreateHero(heroName, heroType);
                    heroes.Add(current);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int heroesPower = heroes.Sum(h => h.Power);

            heroes
                .ForEach(h => Console.WriteLine(h.CastAbility()));

           Console.WriteLine(heroesPower >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}
