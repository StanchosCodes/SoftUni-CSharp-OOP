namespace NeedForSpeed
{
    public class Vehicle
    {
        public virtual double FuelConsumption => 1.25;
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;

        }

        public virtual void Drive(double kilometers)
        {
            if (this.Fuel - (FuelConsumption * kilometers) >= 0)
            {
                this.Fuel -= FuelConsumption * kilometers;
            }
        }
    }
}
