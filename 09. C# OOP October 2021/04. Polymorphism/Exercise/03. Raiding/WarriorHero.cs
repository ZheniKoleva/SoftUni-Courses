namespace _03.Raiding
{
    public abstract class WarriorHero : BaseHero
    {
        public WarriorHero(string name, int power) 
            : base(name, power)
        {
        }

        public override string CastAbility()
          => $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
    }
}
