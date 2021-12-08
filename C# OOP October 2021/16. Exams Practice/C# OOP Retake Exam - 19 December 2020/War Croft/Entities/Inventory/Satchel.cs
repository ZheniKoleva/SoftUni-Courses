namespace WarCroft.Entities.Inventory
{
    public class Satchel : Bag
    {
        private const int Default_Capacity = 20;

        public Satchel()
            : base(Default_Capacity)
        {
        }
    }
}
