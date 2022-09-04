namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int ComfortValue = 1;
        private const decimal PriceValue = 5m;

        public Ornament()
            : base(ComfortValue, PriceValue)
        {

        }
    }
}
