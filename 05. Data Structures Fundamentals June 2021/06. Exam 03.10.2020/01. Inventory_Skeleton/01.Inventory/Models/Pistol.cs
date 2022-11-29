namespace _01.Inventory.Models
{
    public class Pistol : Weapon
    {
        public Pistol(int id, int maxCapacity, int ammunition)
          : base(id, maxCapacity, ammunition)
        {
            this.Category = Category.Light;
        }
    }
}
