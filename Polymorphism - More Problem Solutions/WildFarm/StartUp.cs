using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] animalInfo = command.Split();
                string[] foodInfo = Console.ReadLine().Split();

                string foodType = foodInfo[0];
                int foodQuantity = int.Parse(foodInfo[1]);

                Animal newAnimal = FindAnimal(animalInfo);
                Food food = FindFood(foodType, foodQuantity);

                animals.Add(newAnimal);

                Console.WriteLine(newAnimal.ProduceSound());
                newAnimal.Eat(food);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        public static Food FindFood(string type, int quantity)
        {
            Food food;
            if (type == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (type == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else
            {
                return null;
            }

            return food;
        }

        public static Animal FindAnimal(string[] animalInfo)
        {
            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);

            Animal animal;
            if (type == "Owl")
            {
                double wingSize = double.Parse(animalInfo[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                double wingSize = double.Parse(animalInfo[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else if (type == "Mouse")
            {
                string livingRegion = animalInfo[3];
                animal = new Mouse(name, weight, livingRegion);
            }
            else if (type == "Dog")
            {
                string livingRegion = animalInfo[3];
                animal = new Dog(name, weight, livingRegion);
            }
            else if (type == "Cat")
            {
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];
                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (type == "Tiger")
            {
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];
                animal = new Tiger(name, weight, livingRegion, breed);
            }
            else
            {
                return null;
            }

            return animal;
        }
    }
}
