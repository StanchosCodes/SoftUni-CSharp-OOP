namespace FoodShortage
{
    public interface IBuyer : IHuman
    {
        int Food { get; }
        void BuyFood();
    }
}
