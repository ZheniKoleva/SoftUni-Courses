namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int Initial_Size = 3;

        private const int Increase_Size = 3;

        public FreshwaterFish(string name, string species, decimal price)
            :base(name, species, price)
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
