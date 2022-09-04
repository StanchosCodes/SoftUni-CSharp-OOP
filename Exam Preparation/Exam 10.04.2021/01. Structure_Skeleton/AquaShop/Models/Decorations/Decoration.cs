namespace AquaShop.Models.Decorations
{
    using Contracts;

    public abstract class Decoration : IDecoration
    {
        public Decoration(int comfort, decimal price)
        {
            this.Comfort = comfort;
            this.Price = price;
        }
        public int Comfort { get; }

        public decimal Price { get; }
    }
}
