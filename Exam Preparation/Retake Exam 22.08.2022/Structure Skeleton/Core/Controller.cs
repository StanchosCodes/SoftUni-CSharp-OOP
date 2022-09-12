namespace BookingApp.Core
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Repositories;
    using Utilities.Messages;
    using BookingApp.Models.Hotels.Contacts;
    using BookingApp.Models.Hotels;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Models.Rooms;
    using System.Linq;
    using BookingApp.Models.Bookings;

    public class Controller : IController
    {
        private HotelRepository hotels;

        public Controller()
        {
            this.hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = new Hotel(hotelName, category);

            if (this.hotels.Select(hotelName) != null)
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            this.hotels.AddNew(hotel);

            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            this.hotels.All().OrderBy(h => h.FullName);

            List<IRoom> rooms = new List<IRoom>();

            foreach (IHotel hotel in this.hotels.All())
            {
                foreach (IRoom room in hotel.Rooms.All())
                {
                    if (room.PricePerNight > 0)
                    {
                        rooms.Add(room);
                    }
                }
            }

            rooms.OrderBy(r => r.BedCapacity);

            int guests = adults + children;

            bool isCategoryContained = false;

            foreach (IHotel hotel in this.hotels.All())
            {
                if (hotel.Category == category)
                {
                    isCategoryContained = true;
                }
            }

            if (!isCategoryContained)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            if (!rooms.Any(r => r.BedCapacity >= guests))
            {
                return string.Format(OutputMessages.RoomNotAppropriate);
            }

            IRoom correctRoom = null;
            int currCapacity = int.MaxValue;

            foreach (IRoom room in rooms)
            {
                if (room.BedCapacity < currCapacity && room.BedCapacity >= guests)
                {
                    correctRoom = room;
                    currCapacity = room.BedCapacity;
                }
            }

            IHotel correctHotel = this.hotels.All().FirstOrDefault(h => h.Rooms.All().FirstOrDefault(r => r.GetType().Name == correctRoom.GetType().Name) == correctRoom);

            int bookingNumber = correctHotel.Bookings.All().Count + 1;

            Booking booking = new Booking(correctRoom, duration, adults, children, bookingNumber);

            this.hotels.Select(correctHotel.FullName).Bookings.AddNew(booking);

            return string.Format(OutputMessages.BookingSuccessful, bookingNumber, correctHotel.FullName);
        }

        public string HotelReport(string hotelName)
        {
            // "Hotel name: {hotelName}
            // --{ Category} star hotel
            // --Turnover: { hotelTurnover: F2} $
            // --Bookings:

            // Booking number: { Booking1.BookingNumber}
            // Room type: { RoomType}
            // Adults: { AdultsCount}
            // Children: { ChildrenCount}
            // Total amount paid: { totalPaid} $


            if (this.hotels.Select(hotelName) == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            StringBuilder sb = new StringBuilder();

            foreach (IHotel hotel in this.hotels.All().Where(h => h.FullName == hotelName))
            {
                string bookings = "none";

                if (hotel.Bookings.All().Count > 0)
                {
                    bookings = "";

                    foreach (Booking booking in hotel.Bookings.All())
                    {
                        bookings += booking.BookingSummary() + Environment.NewLine + Environment.NewLine;
                    }
                }

                sb.AppendLine($"Hotel name: {hotelName}");
                sb.AppendLine($"--{hotel.Category} star hotel");
                sb.AppendLine($"--Turnover: {hotel.Turnover:f2} $");
                sb.AppendLine($"--Bookings:");
                sb.AppendLine();
                sb.AppendLine($"{bookings}");
            }

            return sb.ToString().Trim();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (this.hotels.Select(hotelName) == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (roomTypeName == "Apartment")
            {
                if (this.hotels.Select(hotelName).Rooms.Select(roomTypeName) == null)
                {
                    return string.Format(OutputMessages.RoomTypeNotCreated);
                }
            }
            else if (roomTypeName == "DoubleBed")
            {
                if (this.hotels.Select(hotelName).Rooms.Select(roomTypeName) == null)
                {
                    return string.Format(OutputMessages.RoomTypeNotCreated);
                }
            }
            else if (roomTypeName == "Studio")
            {
                if (this.hotels.Select(hotelName).Rooms.Select(roomTypeName) == null)
                {
                    return string.Format(OutputMessages.RoomTypeNotCreated);
                }
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            if (this.hotels.Select(hotelName).Rooms.Select(roomTypeName).PricePerNight > 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PriceAlreadySet));
            }

            this.hotels.Select(hotelName).Rooms.Select(roomTypeName).SetPrice(price);

            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (this.hotels.Select(hotelName) == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (this.hotels.Select(hotelName).Rooms.Select(roomTypeName) != null)
            {
                return string.Format(OutputMessages.RoomTypeAlreadyCreated);
            }

            IRoom room;

            if (roomTypeName == "Apartment")
            {
                room = new Apartment();
            }
            else if (roomTypeName == "DoubleBed")
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == "Studio")
            {
                room = new Studio();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            this.hotels.Select(hotelName).Rooms.AddNew(room);

            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
    }
}
