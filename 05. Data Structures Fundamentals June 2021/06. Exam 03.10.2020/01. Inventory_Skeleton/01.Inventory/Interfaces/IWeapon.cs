namespace _01.Inventory.Interfaces
{
    using _01.Inventory.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IWeapon
    {
        int Id { get;  }

        int Ammunition { get; set; }

        int MaxCapacity { get; set; }

        Category Category { get; set; }
    }
}
