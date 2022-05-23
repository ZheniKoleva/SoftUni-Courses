namespace _07.MilitaryElite.Interfaces
{
    using Enumerators;

    public interface IMission
    {
        public string CodeName { get; }

        public State State { get; }

        public void CompleteMission();
    }
}
