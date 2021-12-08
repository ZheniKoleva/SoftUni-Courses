namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int Default_Capacity = 50;

        public FreshwaterAquarium(string name) 
            : base(name, Default_Capacity)
        {
        }
    }
}
