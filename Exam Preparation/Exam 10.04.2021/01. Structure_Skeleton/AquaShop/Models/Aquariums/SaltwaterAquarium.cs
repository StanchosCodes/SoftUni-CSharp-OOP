namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int CapacityValue = 25;

        public SaltwaterAquarium(string name)
            : base(name, CapacityValue)
        {

        }
    }
}
