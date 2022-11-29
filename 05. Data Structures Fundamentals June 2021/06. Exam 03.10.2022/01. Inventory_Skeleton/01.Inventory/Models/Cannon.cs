namespace _01.Inventory.Models
{
    public class Cannon : Weapon
    {
        public Cannon(int id, int maxCapacity, int ammunition) 
            : base(id, maxCapacity, ammunition)
        {
            this.Category = Category.Heavy;
        }
    }
}
