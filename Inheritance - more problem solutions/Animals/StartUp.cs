using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> allAnimals = new List<Animal>();

            string currAnimal;
            while ((currAnimal = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string currName = info[0];
                    int currAge = int.Parse(info[1]);

                    Animal newAnimal = null;

                    if (currAnimal == "Dog")
                    {
                        string currGender = info[2];
                        newAnimal = new Dog(currName, currAge, currGender);
                    }
                    else if (currAnimal == "Frog")
                    {
                        string currGender = info[2];
                        newAnimal = new Frog(currName, currAge, currGender);
                    }
                    else if (currAnimal == "Cat")
                    {
                        string currGender = info[2];
                        newAnimal = new Cat(currName, currAge, currGender);
                    }
                    else if (currAnimal == "Kitten")
                    {
                        newAnimal = new Kitten(currName, currAge);
                    }
                    else if (currAnimal == "Tomcat")
                    {
                        newAnimal = new Tomcat(currName, currAge);
                    }
                    else
                    {
                        throw new InvalidOperationException("Inalid type!");
                    }

                    allAnimals.Add(newAnimal);
                }
                catch (Exception)
                {

                    Console.WriteLine("Invalid input!");
                }
            }

            foreach (Animal animal in allAnimals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
