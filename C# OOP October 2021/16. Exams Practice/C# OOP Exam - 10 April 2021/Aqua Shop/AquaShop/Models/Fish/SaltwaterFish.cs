namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int Initial_Size = 5;

        private const int Increase_Size = 2;

        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.Size = Initial_Size;
        }

        public override int Size
        {
            get => base.Size;
            protected set => base.Size = value;
        }

        public override void Eat() => this.Size += Increase_Size;
    }
}
