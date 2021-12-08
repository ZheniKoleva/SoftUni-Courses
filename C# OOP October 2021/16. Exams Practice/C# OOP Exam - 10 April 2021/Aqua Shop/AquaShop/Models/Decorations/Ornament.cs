namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int Default_Comfort = 1;

        private const decimal Default_Price = 5;


        public Ornament() 
            : base(Default_Comfort, Default_Price)
        {
        }
    }
}
