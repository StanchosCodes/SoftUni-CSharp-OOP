using System;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Reptile reptile = new Reptile("I am reptile");
            Mammal mammal = new Mammal("I am mammal");
            Lizard lizard = new Lizard("I am a reptile too");
            Snake snake = new Snake("Also reptile");
            Gorilla gorilla = new Gorilla("I am a mammal too");
            Bear bear = new Bear("Also mammal");

            Console.WriteLine(reptile.Name);
            Console.WriteLine(mammal.Name);
            Console.WriteLine(lizard.Name);
            Console.WriteLine(snake.Name);
            Console.WriteLine(gorilla.Name);
            Console.WriteLine(bear.Name);
        }
    }
}