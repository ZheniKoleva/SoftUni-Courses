namespace _06.FoodShortage
{
    public class Rebel : IPerson, IBuyer
    {
        private const int FoodBought = 5;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            Food = 0;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Group { get; private set; }

        public int Food { get ; private set ; }

        public void BuyFood() => this.Food += FoodBought;       
    }
}
