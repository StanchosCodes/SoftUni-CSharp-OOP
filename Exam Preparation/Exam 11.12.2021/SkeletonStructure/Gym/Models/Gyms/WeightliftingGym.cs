namespace Gym.Models.Gyms
{
    public class WeightliftingGym : Gym
    {
        private const int CapacityValue = 20;

        public WeightliftingGym(string name)
            : base(name, CapacityValue)
        {
        }
    }
}
