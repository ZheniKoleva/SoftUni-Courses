namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int Default_Comfort = 5;

        private const decimal Default_Price = 10;


        public Plant()
            : base(Default_Comfort, Default_Price)
        {
        }
    }
}
