namespace Gym.Models.Gyms
{
    public class BoxingGym : Gym
    {
        private const int CapacityValue = 15;

        public BoxingGym(string name)
            : base(name, CapacityValue)
        {
        }
    }
}
