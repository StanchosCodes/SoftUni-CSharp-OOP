namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double WeightValue = 227;
        private const decimal PriceValue = 120;

        public BoxingGloves()
            : base(WeightValue, PriceValue)
        {
        }
    }
}
