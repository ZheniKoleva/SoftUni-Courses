namespace _03.Raiding
{
    public abstract class BaseHero
    {
        protected BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name { get;  }

        public virtual int Power { get; }

        public abstract string CastAbility();           
    }
}
