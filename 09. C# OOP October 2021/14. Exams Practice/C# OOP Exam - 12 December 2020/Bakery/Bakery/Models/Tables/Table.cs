using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Bakery.Utilities.Messages;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Models.BakedFoods.Contracts;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private ICollection<IBakedFood> foodOrders;

        private ICollection<IDrink> drinkOrders ;

        private int tableNumber;

        private int capacity;

        private int numberOfPeople;

        private decimal pricePerPerson;

        private bool isReserved;

       
        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;            
            PricePerPerson = pricePerPerson;
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }

        public int TableNumber
        { 
            get => tableNumber;
            private set => tableNumber = value;
        }

        public int Capacity 
        { 
            get => capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                
                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson 
        { 
            get => pricePerPerson; 
            private set => pricePerPerson = value; 
        }

        public bool IsReserved 
        { 
            get => isReserved; 
            private set => isReserved = false; 
        }

        public decimal Price => pricePerPerson * numberOfPeople;       

        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
            numberOfPeople = 0;
            isReserved = false;
        }

        public decimal GetBill()
            => foodOrders.Sum(x => x.Price) + drinkOrders.Sum(x => x.Price) + Price;
      
        public string GetFreeTableInfo()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Table: {TableNumber}")
                .AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Capacity: {Capacity}")
                .Append($"Price per Person: {PricePerPerson}");

            return output.ToString();
        }

        public void OrderDrink(IDrink drink)
            => drinkOrders.Add(drink);       

        public void OrderFood(IBakedFood food)
            => foodOrders.Add(food);      

        public void Reserve(int numberOfPeople)
        {
            NumberOfPeople = numberOfPeople;
            isReserved = true;
        }
    }
}
