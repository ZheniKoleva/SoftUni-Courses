namespace _01.Inventory.Models
{
    public class RocketLauncher : Weapon
    {
        public RocketLauncher(int id, int maxCapacity, int ammunition)
            : base(id, maxCapacity, ammunition)
        {
            this.Category = Category.Heavy;
        }
    }
}
