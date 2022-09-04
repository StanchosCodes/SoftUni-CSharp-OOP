namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int CapacityValue = 50;
        public FreshwaterAquarium(string name)
            : base(name, CapacityValue)
        {

        }
    }
}
