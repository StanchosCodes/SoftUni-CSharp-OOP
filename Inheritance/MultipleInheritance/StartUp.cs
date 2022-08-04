namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            Puppy puppy = new Puppy();

            dog.Bark();
            dog.Eat();
            puppy.Weep();
            puppy.Bark();
            puppy.Eat();
        }
    }
}
