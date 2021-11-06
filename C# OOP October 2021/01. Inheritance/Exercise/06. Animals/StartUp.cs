namespace Animals
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string animalType = Console.ReadLine();

            while (animalType != "Beast!")
            {
                string[] animalData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Animal currentAnimal;

                try
                {
                    currentAnimal = CreateAnimal(animalType, animalData);                    
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae);
                    animalType = Console.ReadLine();
                    continue;
                }

                animals.Add(currentAnimal);
                animalType = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, animals));
            
        }

        private static Animal CreateAnimal(string animalType, string[] animalData)
        {
            string name = animalData[0];
            int age = int.Parse(animalData[1]);
            string gender = animalData[2];

            Animal animal = animalType switch
            {
                "Dog" => new Dog(name, age, gender),
                "Frog" => new Frog(name, age, gender),
                "Cat" => new Cat(name, age, gender),
                "Kitten" => new Kitten(name, age),
                "Tomcat" => new Tomcat(name, age),
                _ => throw new ArgumentException("Invalid input!"),
            };
            return animal;
        }
    }
}
