namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Cake cake = new Cake("Cakish");
            Soup soup = new Soup("Fish Soup", 2.50m, 300);
            Fish fish = new Fish("fish", 5);
        }
    }
}