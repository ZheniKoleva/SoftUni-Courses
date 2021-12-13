namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int Default_Energy = 100;

        public HappyBunny(string name) 
            : base(name, Default_Energy)
        {
        }
    }
}
