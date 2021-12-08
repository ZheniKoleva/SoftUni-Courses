using System.Linq;
using System.Text;
using System.Collections.Generic;


using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private IList<IBakedFood> bakedFoods;

        private IList<IDrink> drinks;

        private IList<ITable> tables;

        private decimal totalIncome;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
            totalIncome = 0;
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            if (type == DrinkType.Tea.ToString())
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == DrinkType.Water.ToString())
            {
                drink = new Water(name, portion, brand);
            }

            drinks.Add(drink);

            return string.Format(OutputMessages.DrinkAdded, drink.Name, drink.Brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood bakedFood = null;

            if (type == BakedFoodType.Bread.ToString())
            {
                bakedFood = new Bread(name, price);
            }
            else if (type == BakedFoodType.Cake.ToString())
            {
                bakedFood = new Cake(name, price);
            }

            bakedFoods.Add(bakedFood);

            return string.Format(OutputMessages.FoodAdded, bakedFood.Name, bakedFood.GetType().Name);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            if (type == TableType.InsideTable.ToString())
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == TableType.OutsideTable.ToString())
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            tables.Add(table);

            return string.Format(OutputMessages.TableAdded, table.TableNumber);
        }

        public string GetFreeTablesInfo()
        {
            IEnumerable<ITable> availableTables = tables.Where(x => !x.IsReserved);

            StringBuilder output = new StringBuilder();

            foreach (var table in availableTables)
            {
                output.AppendLine(table.GetFreeTableInfo());
            }

            return output.ToString().TrimEnd();
        }

        public string GetTotalIncome()
            => string.Format(OutputMessages.TotalIncome, totalIncome);       

        public string LeaveTable(int tableNumber)
        {
            ITable tableToLeave = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            decimal bill = tableToLeave.GetBill();
            totalIncome += bill;
            tableToLeave.Clear();

            StringBuilder output = new StringBuilder();
            output.AppendLine($"Table: {tableToLeave.TableNumber}")
                .Append($"Bill: {bill:f2}");

            return output.ToString();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IDrink drink = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);
            
            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);

            return $"Table {table.TableNumber} ordered {drink.Name} {drink.Brand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IBakedFood food = bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);

            return string.Format(OutputMessages.FoodOrderSuccessful, table.TableNumber, food.Name);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable tableToReserve = tables
                .FirstOrDefault(x => !x.IsReserved && x.Capacity >= numberOfPeople);

            if (tableToReserve == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);            
            }

            tableToReserve.Reserve(numberOfPeople);

            return string.Format(OutputMessages.TableReserved, tableToReserve.TableNumber, numberOfPeople);

        }
    }
}
