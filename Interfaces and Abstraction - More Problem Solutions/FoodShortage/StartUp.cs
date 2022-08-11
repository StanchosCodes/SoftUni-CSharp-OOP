using System;
using System.Linq;
using System.Collections.Generic;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int people = int.Parse(Console.ReadLine());

            for (int i = 0; i < people; i++)
            {
                string[] peopleInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = peopleInfo[0];
                int age = int.Parse(peopleInfo[1]);

                if (peopleInfo.Length == 4)
                {
                    string id = peopleInfo[2];
                    string birthdate = peopleInfo[3];

                    IBuyer citizenBuyer = new Citizen(name, age, id, birthdate);
                    buyers.Add(citizenBuyer);
                }
                else if (peopleInfo.Length == 3)
                {
                    string group = peopleInfo[2];

                    IBuyer rebelBuyer = new Rebel(name, age, group);
                    buyers.Add(rebelBuyer);
                }
            }

            string currName;
            while ((currName = Console.ReadLine()) != "End")
            {
                foreach (var buyer in buyers)
                {
                    if (buyer.Name == currName)
                    {
                        buyer.BuyFood();
                    }
                }
            }

            int totalFoodAmount = 0;

            foreach (var buyer in buyers)
            {
                totalFoodAmount += buyer.Food;
            }

            Console.WriteLine(totalFoodAmount);
        }
    }
}
