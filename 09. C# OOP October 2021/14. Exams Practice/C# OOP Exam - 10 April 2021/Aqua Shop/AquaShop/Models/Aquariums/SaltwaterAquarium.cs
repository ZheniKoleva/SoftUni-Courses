namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int Default_Capacity = 25;


        public SaltwaterAquarium(string name)
            : base(name, Default_Capacity)
        {
        }
    }
}
