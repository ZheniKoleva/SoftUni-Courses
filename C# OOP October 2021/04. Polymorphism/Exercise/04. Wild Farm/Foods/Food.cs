namespace _04.WildFarm.Foods
{
    public abstract class Food : IFood
    {   
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; }
    }
}
