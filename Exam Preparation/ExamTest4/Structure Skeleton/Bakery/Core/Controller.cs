namespace Bakery.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;
    using Models.BakedFoods;
    using Models.Drinks;
    using Models.Tables;
    using Models.BakedFoods.Contracts;
    using Models.Drinks.Contracts;
    using Models.Tables.Contracts;

    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink;

            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else
            {
                drink = new Water(name, portion, brand);
            }

            this.drinks.Add(drink);

            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food;

            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            else
            {
                food = new Cake(name, price);
            }

            this.bakedFoods.Add(food);

            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table;

            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            this.tables.Add(table);

            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ITable table in this.tables.Where(t => !t.IsReserved))
            {
                sb.AppendLine($"{table.GetFreeTableInfo()}");
            }

            return sb.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            decimal bill = table.GetBill();
            totalIncome += bill;

            table.Clear();

            string result = $"Table: {tableNumber}{Environment.NewLine}Bill: {bill:f2}";

            return result;
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IDrink drink = this.drinks.FirstOrDefault(f => f.Name == drinkName);

            if (drink != null && drink.Brand == drinkBrand)
            {
                table.OrderDrink(drink);

                return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, drinkName + " " + drinkBrand);
            }

            return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IBakedFood food = this.bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);

            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables.FirstOrDefault(t => !t.IsReserved);

            if (table != null && table.Capacity >= numberOfPeople)
            {
                table.Reserve(numberOfPeople);
                return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
            }
            else
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
        }
    }
}
