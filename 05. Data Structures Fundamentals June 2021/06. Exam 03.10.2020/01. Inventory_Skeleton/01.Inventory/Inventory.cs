namespace _01.Inventory
{
    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Inventory : IHolder
    {
        private Dictionary<int, IWeapon> weapons;
        private List<IWeapon> listWeapons;

        public Inventory()
        {
            weapons = new Dictionary<int, IWeapon>();
            listWeapons = new List<IWeapon>();
        }

        public int Capacity => weapons.Count;

        public void Add(IWeapon weapon)
        {
            weapons.Add(weapon.Id, weapon);
            listWeapons.Add(weapon);
        }

        public void Clear()
        {
            weapons.Clear();
            listWeapons.Clear();
        }      

        public bool Contains(IWeapon weapon) => weapons.ContainsKey(weapon.Id);       

        public void EmptyArsenal(Category category)
        {
            foreach (var item in listWeapons)
            {
                if (item.Category == category)
                {
                    item.Ammunition = 0;                   
                }
            }
        }

        public bool Fire(IWeapon weapon, int ammunition)
        {
            IsWeaponExist(weapon);

            if (weapons[weapon.Id].Ammunition >= ammunition)
            {
                weapons[weapon.Id].Ammunition -= ammunition;
                return true;
            }

            return false;
        }

        public IWeapon GetById(int id)
            => weapons.ContainsKey(id) ? weapons[id] : null;
       

        public IEnumerator GetEnumerator()
        {
            return listWeapons.GetEnumerator();
        }

        public int Refill(IWeapon weapon, int ammunition)
        {
            IsWeaponExist(weapon);

            weapons[weapon.Id].Ammunition += ammunition;

            if (weapons[weapon.Id].Ammunition > weapons[weapon.Id].MaxCapacity)
            {
                weapons[weapon.Id].Ammunition = weapons[weapon.Id].MaxCapacity;
            }

            return weapons[weapon.Id].Ammunition;
        }

        private void IsWeaponExist(IWeapon weapon)
        {
            if (!weapons.ContainsKey(weapon.Id))
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }
        }

        public IWeapon RemoveById(int id)
        {
            IsWeaponExist(weapons[id]);

            IWeapon weaponToRemove = weapons[id];
            weapons.Remove(weaponToRemove.Id);
            listWeapons.Remove(weaponToRemove);

            return weaponToRemove;
        }

        public int RemoveHeavy()
        {
            int removedCount = 0;
            List<IWeapon> listNotHeavy = new List<IWeapon>();
            Dictionary<int, IWeapon> withoutHeavy = new Dictionary<int, IWeapon>();            

            foreach (var item in listWeapons)
            {
                if (item.Category == Category.Heavy)
                {                    
                    removedCount++;
                }
                else
                {
                    listNotHeavy.Add(item);
                    withoutHeavy.Add(item.Id, item);
                }
            }           

            if (removedCount > 0)
            {
                listWeapons = listNotHeavy;
                weapons = withoutHeavy;
            }

            return removedCount;
        }

        public List<IWeapon> RetrieveAll() => new List<IWeapon>(listWeapons);
        

        public List<IWeapon> RetriveInRange(Category lower, Category upper)
        {
            List<IWeapon> result = new List<IWeapon>();

            foreach (var item in listWeapons)
            {
                if (item.Category >= lower && item.Category <= upper)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            IsWeaponExist(firstWeapon);
            IsWeaponExist(secondWeapon);

            int firstInx = listWeapons.IndexOf(firstWeapon);           
            int secondInx = listWeapons.IndexOf(secondWeapon);

            if (firstWeapon.Category == secondWeapon.Category)
            {
                IWeapon temp = firstWeapon;
                listWeapons[firstInx] = secondWeapon;
                listWeapons[secondInx] = temp;
            }            
        }
    }
}
