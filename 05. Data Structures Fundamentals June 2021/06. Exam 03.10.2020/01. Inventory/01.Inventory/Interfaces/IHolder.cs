namespace _01.Inventory.Interfaces
{
    using _01.Inventory.Models;
    using System.Collections;
    using System.Collections.Generic;

    public interface IHolder : IEnumerable
    {
        int Capacity { get; }

        void Add(IWeapon weapon);

        IWeapon GetById(int id);

        bool Contains(IWeapon weapon);

        int Refill(IWeapon weapon, int ammunition);

        bool Fire(IWeapon weapon, int ammunition);

        IWeapon RemoveById(int id);

        void Swap(IWeapon firstWeapon, IWeapon secondWeapon);

        void Clear();

        List<IWeapon> RetrieveAll();

        List<IWeapon> RetriveInRange(Category lower, Category upper);

        void EmptyArsenal(Category category);

        int RemoveHeavy();
    }
}
