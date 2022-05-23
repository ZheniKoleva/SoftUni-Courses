using System;
using System.Collections.Generic;
using System.Text;

namespace _06.StoreBoxes
{
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
