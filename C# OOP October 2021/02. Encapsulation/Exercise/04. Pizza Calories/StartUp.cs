namespace _04.PizzaCalories
{
    using System;    

    public class StartUp
    {
        static void Main(string[] args)
        {          
            try
            {                
                Pizza pizza = CreatePizza();

                Dough dough = CreateDough();
                pizza.Dough = dough;

                AddToppings(pizza);
                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);                
            }
        }

        

        private static void AddToppings(Pizza pizza)
        {
            string toppings = Console.ReadLine();

            while (toppings != "END")
            {
                string[] toppingData = toppings.Split();

                string toppingType = toppingData[1];
                double weight = double.Parse(toppingData[2]);

                Topping current = new Topping(toppingType, weight);

                pizza.AddTopping(current);
                toppings = Console.ReadLine();
            }
        }

        private static Dough CreateDough()
        {
            string[] doughData = ReadData();

            string flourType = doughData[1];
            string backingTechnique = doughData[2];
            double weight = double.Parse(doughData[3]);

            return new Dough(flourType, backingTechnique, weight);
        }

        private static Pizza CreatePizza()
        {
            string pizzaName = ReadData()[1];

            return new Pizza(pizzaName);
        }

        private static string[] ReadData()
        {
            return Console.ReadLine().Split();
        }
    }
}
