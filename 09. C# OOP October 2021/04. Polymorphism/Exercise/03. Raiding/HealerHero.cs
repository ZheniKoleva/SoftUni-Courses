namespace _03.Raiding
{
    public abstract class HealerHero : BaseHero
    {
        protected HealerHero(string name, int power) 
            : base(name, power)
        {
        }

        public override string CastAbility()
            => $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
    }
}
