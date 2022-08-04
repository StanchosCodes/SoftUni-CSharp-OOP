namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] peopleAndMoney = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            foreach (string person in peopleAndMoney)
            {
                string currPersonName = person.Split('=')[0];
                decimal currMoney = decimal.Parse(person.Split('=')[1]);

                Person newPerson = new Person(currPersonName, currMoney);
                people.Add(newPerson);
            }

            string[] productsAndCost = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (string product in productsAndCost)
            {
                string currProductName = product.Split('=', StringSplitOptions.RemoveEmptyEntries)[0];
                decimal currCost = decimal.Parse(product.Split('=', StringSplitOptions.RemoveEmptyEntries)[1]);

                Product newProduct = new Product(currProductName, currCost);
                products.Add(newProduct);
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string currPersonName = cmdArgs[0];
                string currProductName = cmdArgs[1];

                int currPersonIndex = people.FindIndex(p => p.Name == currPersonName);
                int currProductIndex = products.FindIndex(pr => pr.Name == currProductName);

                if (currPersonIndex < 0 || currProductIndex < 0)
                {
                    continue;
                }

                if (people[currPersonIndex].Money - products[currProductIndex].Cost >= 0)
                {
                    people[currPersonIndex].Money -= products[currProductIndex].Cost;
                    people[currPersonIndex].Products.Add(products[currProductIndex]);
                    Console.WriteLine($"{currPersonName} bought {currProductName}");
                }
                else
                {
                    Console.WriteLine($"{currPersonName} can't afford {currProductName}");
                }
            }

            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
