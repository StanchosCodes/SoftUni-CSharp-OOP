using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //string[] doughInfo = Console.ReadLine().Split();
            //string[] toppingInfo = Console.ReadLine().Split();

            //string doughType = doughInfo[1];
            //string doughTechnique = doughInfo[2];
            //double doughGrams = double.Parse(doughInfo[3]);

            //string toppingType = toppingInfo[1];
            //double toppingGrams = double.Parse(toppingInfo[2]);

            //Dough dough = new Dough(doughType, doughTechnique, doughGrams);
            //Console.WriteLine(dough.TotalCalories);

            //Topping topping = new Topping(toppingType, toppingGrams);
            //Console.WriteLine(topping.TotalCalories);

            string[] pizzaInfo = Console.ReadLine().Split(' ');

            Pizza pizza = new Pizza(pizzaInfo[1]);

            string[] doughInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string doughType = doughInfo[1].ToLower();
            string doughTechnique = doughInfo[2].ToLower();
            double doughGrams = double.Parse(doughInfo[3]);

            pizza.Dough = new Dough(doughType, doughTechnique, doughGrams);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] toppingInfo = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string toppingType = toppingInfo[1].ToLower();
                double toppingGrams = double.Parse(toppingInfo[2]);

                Topping topping = new Topping(toppingType, toppingGrams);
                pizza.AddTopping(topping);
            }

            Console.WriteLine(pizza);
        }
    }
}
