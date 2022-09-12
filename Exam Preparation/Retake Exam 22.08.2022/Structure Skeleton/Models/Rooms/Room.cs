namespace BookingApp.Models.Rooms
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;

    public class Room : IRoom
    {
        private double pricePerNight = 0;

        public Room(int bedCapacity)
        {
            this.BedCapacity = bedCapacity;
            this.PricePerNight = pricePerNight;
        }

        public int BedCapacity { get; private set; }

        public double PricePerNight
        {
            get
            {
                return this.pricePerNight;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.PricePerNightNegative));
                }

                this.pricePerNight = value;
            }
        }

        public virtual void SetPrice(double price)
        {
            this.PricePerNight = price;
        }
    }
}
