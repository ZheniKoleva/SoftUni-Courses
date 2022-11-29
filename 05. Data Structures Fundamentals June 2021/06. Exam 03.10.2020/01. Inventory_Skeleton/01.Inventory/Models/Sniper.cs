namespace _01.Inventory.Models
{
    public class Sniper : Weapon
    {
        public Sniper(int id, int maxCapacity, int ammunition)
             : base(id, maxCapacity, ammunition)
        {
            this.Category = Category.Medium;
        }
    }
}
