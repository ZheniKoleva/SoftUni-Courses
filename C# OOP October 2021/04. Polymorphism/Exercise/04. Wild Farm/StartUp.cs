namespace _04.WildFarm
{
    using System;
    using System.Collections.Generic;

    using Animals;
    using Foods;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>();

            string animalInput = Console.ReadLine();

            while (animalInput != "End")
            {  
                string[] animalData = ExtractData(animalInput);

                string foodInput = Console.ReadLine();
                string[] foodData = ExtractData(foodInput);

                try
                {
                    IAnimal animal = CreateAnimal(animalData);
                    animals.Add(animal);

                    IFood food = CreateFood(foodData);

                    Console.WriteLine(animal.ProduseSound());
                    animal.Eat(food);

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);                    
                }
                
                animalInput = Console.ReadLine();
            }

            animals
                .ForEach(animal => Console.WriteLine(animal));            
        }

        private static IFood CreateFood(string[] foodData)
        {
            string type = foodData[0];
            int quantity = int.Parse(foodData[1]);

            return type switch
            {
                "Meat" => new Meat(quantity),
                "Seeds" => new Seeds(quantity),
                "Vegetable" => new Vegetable(quantity),
                "Fruit" => new Fruit(quantity),
                _ => null,
            };
        }

        private static string[] ExtractData(string animalInput)
            => animalInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);       

        private static IAnimal CreateAnimal(string[] animalData)
        {
            string type = animalData[0];
            string animalName = animalData[1];
            double weight = double.Parse(animalData[2]);

            if (type.Equals("Owl") || type.Equals("Hen"))
            {
                double wingsSize = double.Parse(animalData[3]);

                return type switch
                {
                    "Owl" => new Owl(animalName, weight, wingsSize),
                    "Hen" => new Hen(animalName, weight, wingsSize),
                    _ => null,
                };
            }

            if (type.Equals("Dog") || type.Equals("Mouse"))
            {
                string livingRegion = animalData[3];

                return type switch
                {
                    "Mouse" => new Mouse(animalName, weight, livingRegion),
                    "Dog" => new Dog(animalName, weight, livingRegion),
                    _ => null,
                };
            }

            if (type.Equals("Cat") || type.Equals("Tiger"))
            {
                string livingRegion = animalData[3];
                string breed = animalData[4];

                return type switch
                {
                    "Cat" => new Cat(animalName, weight, livingRegion, breed),
                    "Tiger" => new Tiger(animalName, weight, livingRegion, breed),
                    _ => null,
                };

            }            

            return null;
        }
    }
}
