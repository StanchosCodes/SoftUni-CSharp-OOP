namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int ComfortValue = 5;
        private const decimal PriceValue = 10m;

        public Plant()
            : base(ComfortValue, PriceValue)
        {

        }
    }
}
