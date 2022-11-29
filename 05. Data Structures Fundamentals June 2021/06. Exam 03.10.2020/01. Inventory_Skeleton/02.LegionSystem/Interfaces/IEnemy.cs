namespace _02.LegionSystem.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IEnemy : IComparable
    {
        int AttackSpeed { get; set; }

        int Health { get; set; }
    }
}
