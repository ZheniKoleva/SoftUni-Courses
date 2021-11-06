namespace _03.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] peopleData = ReadData();
            string[] productsData = ReadData();

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                AddPeople(people, peopleData);
                AddProducts(products, productsData);
            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                BuyProduct(people, products, command);

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, people));
        }

        private static void BuyProduct(List<Person> people, List<Product> products, string command)
        {
            string[] data = command.Split(' ');

            string personName = data[0];
            string productName = data[1];

            Person client = people.First(p => p.Name.Equals(personName));
            Product product = products.First(p => p.Name.Equals(productName));

            Console.WriteLine(client.BuyProduct(product));
        }

        private static void AddProducts(List<Product> products, string[] productsData)
        {
            for (int i = 0; i < productsData.Length; i++)
            {
                string[] currentProductData = productsData[i].Split('=');
                string name = currentProductData[0];
                decimal money = decimal.Parse(currentProductData[1]);

                Product current = new Product(name, money);
                products.Add(current);
            }
        }

        private static void AddPeople(List<Person> people, string[] peopleData)
        {
            for (int i = 0; i < peopleData.Length; i++)
            {
                string[] currentPersonData = peopleData[i].Split('=');
                string name = currentPersonData[0];
                decimal money = decimal.Parse(currentPersonData[1]);

                Person current = new Person(name, money);
                people.Add(current);
            }
        }

        private static string[] ReadData()
        {
            return Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
