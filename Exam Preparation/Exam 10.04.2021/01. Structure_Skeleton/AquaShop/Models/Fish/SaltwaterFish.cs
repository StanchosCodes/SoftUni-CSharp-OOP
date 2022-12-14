namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private int size;

        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.size = 5;
        }

        public override void Eat()
        {
            this.size += 2;
        }
    }
}
