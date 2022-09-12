﻿namespace BookingApp.Models.Bookings
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;
    using BookingApp.Models.Rooms.Contracts;

    public class Booking : IBooking
    {
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            this.Room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.BookingNumber = bookingNumber;
        }

        public IRoom Room { get; private set; }

        public int ResidenceDuration
        {
            get
            {
                return this.residenceDuration;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.DurationZeroOrLess));
                }

                this.residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get
            {
                return this.adultsCount;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.AdultsZeroOrLess));
                }

                this.adultsCount = value;
            }
        }

        public int ChildrenCount
        {
            get
            {
                return this.childrenCount;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ChildrenNegative));
                }

                this.childrenCount = value;
            }
        }

        public int BookingNumber { get; private set; }

        public string BookingSummary()
        {
            // "Booking number: {BookingNumber}
            // Room type: { RoomType}
            // Adults: { AdultsCount}
            // Children: { ChildrenCount}
            // Total amount paid: { TotalPaid():F2} $"

            double totalPaid = Math.Round(this.ResidenceDuration * this.Room.PricePerNight, 2);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booking number: {this.BookingNumber}");
            sb.AppendLine($"Room type: {this.Room.GetType().Name}");
            sb.AppendLine($"Adults: {this.AdultsCount} Children: {this.ChildrenCount}");
            sb.Append($"Total amount paid: {totalPaid:f2} $");

            return sb.ToString().Trim();
        }
    }
}
