namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            Cat cat = new Cat();

            dog.Bark();
            dog.Eat();
            cat.Meow();
            cat.Eat();
        }
    }
}
