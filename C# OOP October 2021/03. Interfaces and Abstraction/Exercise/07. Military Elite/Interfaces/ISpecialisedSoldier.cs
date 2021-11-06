namespace _07.MilitaryElite.Interfaces
{
    using Enumerators;

    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corps { get; }
    }
}
