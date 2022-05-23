using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StoreBoxes2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxesList = new List<Box>();

            string line = Console.ReadLine();

            while (line != "end")
            {
                Box current = CreateBox(line);

                boxesList.Add(current);

                line = Console.ReadLine();
            }

            boxesList = boxesList
                .OrderByDescending(b => b.PricePerBox)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, boxesList));
        }

        //private static List<Box> ReadData()
        //{
        //    List<Box> itemsData = new List<Box>();

        //    string line = Console.ReadLine();

        //    while (line != "end")
        //    {
        //        Box current = CreateBox(line);

        //        itemsData.Add(current);

        //        line = Console.ReadLine();
        //    }

        //    return itemsData;
        //}

        private static Box CreateBox(string line)
        {
            string[] data = line
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string serialNumber = data[0];
            string itemName = data[1];
            int quantity = int.Parse(data[2]);
            double itemPrice = double.Parse(data[3]);

            double pricePerBox = quantity * itemPrice;
            Item currentItem = new Item(itemName, itemPrice);

            Box currentBox = new Box(serialNumber, currentItem, quantity, pricePerBox);

            return currentBox;
        }
    }

    public class Item
    {
        private string name;

        private double price;

        public Item(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }
    }


    public class Box
    {
        private string serialNumber;

        private Item itemName;

        private int quantity;

        private double pricePerBox;


        public Box(string serialNumber, Item itemName, int quantity, double pricePerBox)
        {
            SerialNumber = serialNumber;
            ItemName = itemName;
            Quantity = quantity;
            PricePerBox = pricePerBox;
        }

        public string SerialNumber { get; set; }

        public Item ItemName { get; set; }

        public int Quantity { get; set; }

        public double PricePerBox { get; set; }


        public override string ToString()
        {
            return $"{SerialNumber}\n" +
                $"-- {ItemName.Name} - ${ItemName.Price:f2}: {Quantity}\n" +
                $"-- ${PricePerBox:f2}";
        }

    }
}
