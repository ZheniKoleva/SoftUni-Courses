using System;

namespace _03.Raiding
{
    public static class HeroCreator
    {
        public static BaseHero CreateHero(string heroName, string type)
        {            
            string heroType = type.ToLower();

            return heroType switch
            {
                "druid" => new Druid(heroName),
                "paladin" => new Paladin(heroName),
                "rogue" => new Rogue(heroName),
                "warrior" => new Warrior(heroName),
                _ => throw new ArgumentException("Invalid hero!"),
            };
        }
    }
}
