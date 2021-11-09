namespace _03.Raiding
{
    public class Warrior : WarriorHero
    {
        private const int DefaultPower = 100;

        public Warrior(string name)
            : base(name, DefaultPower)
        {
        }        
    }
}
