using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] personsData = ReadData();
            List<Person> personList = FillPersonData(personsData);

            string[] productData = ReadData();
            List<Product> productsList = FillProductData(productData);

            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] data = ReadData(line);                

                string personName = data[0];
                string productToBuy = data[1];

                Person client = personList.First(p => p.Name == personName);
                Product product = productsList.First(p => p.Name == productToBuy);
                //double productPrice = productsList.First(p => p.Name == productToBuy).Price;

                BuyProduct(client, product);

                line = Console.ReadLine();
            }

            PrintPersonList(personList);

            //Console.WriteLine(string.Join(Environment.NewLine, personList));
        }

        private static void PrintPersonList(List<Person> personList)
        {
            foreach (var person in personList)
            {
                StringBuilder text = new StringBuilder();
                text.Append(person.Name);
                text.Append(" - ");

                if (person.ProductsBought.Count > 0)
                {
                    text.Append(string.Join(", ", person.ProductsBought));
                }
                else
                {
                    text.Append("Nothing bought");
                }

                Console.WriteLine(text);
            }
        }

        private static void BuyProduct(Person client, Product product)
        {
            if (client.MoneyHave >= product.Price)
            {
                client.ProductsBought.Add(product.Name);
                client.MoneyHave -= product.Price;
                Console.WriteLine($"{client.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{client.Name} can't afford {product.Name}");
            }
        }

        private static List<Product> FillProductData(string[] productData)
        {
            List<Product> products = new List<Product>();

            for (int i = 0; i < productData.Length - 1; i += 2)
            {
                string name = productData[i];
                double price = double.Parse(productData[i + 1]);

                products.Add(new Product(name, price));
            }

            return products;
        }

        private static List<Person> FillPersonData(string[] personsData)
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < personsData.Length; i += 2)
            {
                string name = personsData[i];
                double money = double.Parse(personsData[i + 1]);
                
                people.Add(new Person(name, money));
            }

            return people;
        }

        private static string[] ReadData()
        {
            return Console.ReadLine()
                .Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static string[] ReadData(string line)
        {
            return line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }

    public class Product
    {
        private string name;

        private double price;

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

    }

    public class Person
    {
        private string name;

        private double moneyToSpend;

        private List<string> productsBought;

        public Person(string name, double money)
        {
            Name = name;
            MoneyHave = money;
            ProductsBought = new List<string>();
        }

        public string Name { get; set; }

        public double MoneyHave { get; set; }

        public List<string> ProductsBought { get; set; }

        //public override string ToString()
        //{
        //    StringBuilder text = new StringBuilder();
        //    text.Append(Name);
        //    text.Append(" - ");

        //    if (ProductsBought.Count > 0)
        //    {
        //        text.Append(string.Join(", ", ProductsBought));
        //    }
        //    else
        //    {
        //        text.Append("Nothing bought");
        //    }

        //    return text.ToString();
        //}
    }

}

