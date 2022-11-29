namespace _02.LegionSystem.Interfaces
{
    using System.Collections.Generic;

    public interface IArmy
    {
        void Create(IEnemy enemy);

        int Size { get; }

        IEnemy GetByAttackSpeed(int speed);

        bool Contains(IEnemy enemy);

        IEnemy GetFastest();

        IEnemy GetSlowest();

        void ShootFastest();

        void ShootSlowest();

        IEnemy[] GetOrderedByHealth();

        List<IEnemy> GetFaster(int speed);

        List<IEnemy> GetSlower(int speed);
    }
}
