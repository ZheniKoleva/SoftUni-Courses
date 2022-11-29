namespace _01.Inventory.Models
{
    public class Minigun : Weapon
    {
        public Minigun(int id, int maxCapacity, int ammunition)
            : base(id, maxCapacity, ammunition)
        {
            this.Category = Category.Medium;
        }
    }
}
