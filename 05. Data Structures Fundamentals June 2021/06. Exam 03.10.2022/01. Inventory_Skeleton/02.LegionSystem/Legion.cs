namespace _02.LegionSystem
{
    using _02.LegionSystem.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Legion : IArmy
    {   
        private OrderedSet<IEnemy> ordered;

        public Legion()
        {
            ordered = new OrderedSet<IEnemy>();            
        }

        public int Size => ordered.Count;

        public bool Contains(IEnemy enemy) => ordered.Contains(enemy);


        public void Create(IEnemy enemy)
        {
            if (!Contains(enemy))
            {               
                ordered.Add(enemy);
            }
        }

        private void CheckIfEmpty()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }
        }

        public IEnemy GetByAttackSpeed(int speed)
            => ordered.FirstOrDefault(x => x.AttackSpeed == speed);

        public List<IEnemy> GetFaster(int speed)
            => ordered.Where(x => x.AttackSpeed > speed).ToList();

        public IEnemy GetFastest()
        {
            CheckIfEmpty();

            return ordered.GetLast();
        }

        public IEnemy[] GetOrderedByHealth()
            => ordered.OrderByDescending(x => x.Health).ToArray();

        public List<IEnemy> GetSlower(int speed)
            => ordered.Where(x => x.AttackSpeed < speed).ToList();

        public IEnemy GetSlowest()
        {
            CheckIfEmpty();

            return ordered.GetFirst();
        }

        public void ShootFastest()
        {
            CheckIfEmpty();           
            ordered.RemoveLast();
        }

        public void ShootSlowest()
        {
            CheckIfEmpty();           
            ordered.RemoveFirst();
        }
    }
}
