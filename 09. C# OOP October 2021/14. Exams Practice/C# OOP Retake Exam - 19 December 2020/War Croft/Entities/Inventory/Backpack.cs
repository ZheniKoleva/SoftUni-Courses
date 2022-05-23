namespace WarCroft.Entities.Inventory
{
    public class Backpack : Bag
    {
        private const int Default_Capacity = 100;

        public Backpack() 
            : base(Default_Capacity)
        {
        }
    }
}
