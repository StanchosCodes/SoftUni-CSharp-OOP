namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double WeightValue = 10000;
        private const decimal PriceValue = 80;

        public Kettlebell()
            : base(WeightValue, PriceValue)
        {
        }
    }
}
