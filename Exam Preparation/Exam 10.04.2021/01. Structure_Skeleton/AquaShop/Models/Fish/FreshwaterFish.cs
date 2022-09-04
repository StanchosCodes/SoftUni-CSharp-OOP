namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private int size;

        public FreshwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.size = 3;
        }

        public override void Eat()
        {
            this.size += 3;
        }
    }
}
