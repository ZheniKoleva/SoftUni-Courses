namespace _03.Raiding
{
    public class Paladin : HealerHero
    {
        private const int DefaultPower = 100;

        public Paladin(string name) 
            : base(name, DefaultPower)
        {
        }        
    }
}
