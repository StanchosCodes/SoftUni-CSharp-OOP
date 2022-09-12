namespace BookingApp.Models.Hotels
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Contacts;
    using Utilities.Messages;
    using BookingApp.Repositories.Contracts;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Models.Bookings.Contracts;
    using Repositories;

    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private IRepository<IRoom> rooms;
        private IRepository<IBooking> bookings;

        public Hotel(string fullName, int category)
        {
            this.FullName = fullName;
            this.Category = category;
            this.rooms = new RoomRepository();
            this.bookings = new BookingRepository();
        }

        public string FullName
        {
            get
            {
                return this.fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.HotelNameNullOrEmpty));
                }

                this.fullName = value;
            }
        }

        public int Category
        {
            get
            {
                return this.category;
            }
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCategory));
                }

                this.category = value;
            }
        }

        public double Turnover
        {
            get
            {
                double sum = 0;

                foreach (IBooking booking in this.Bookings.All())
                {
                    sum += Math.Round(booking.ResidenceDuration * booking.Room.PricePerNight, 2);
                    //Math.Round(this.ResidenceDuration * this.Room.PricePerNight, 2)
                }

                return Math.Round(sum, 2);
            }
        }

        public IRepository<IRoom> Rooms
        {
            get
            {
                return this.rooms;
            }
            set
            {
                this.rooms = value;
            }
        }
        public IRepository<IBooking> Bookings
        {
            get
            {
                return this.bookings;
            }
            set
            {
                this.bookings = value;
            }
        }
    }
}
