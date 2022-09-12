namespace BookingApp.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Bookings.Contracts;

    public class BookingRepository : IRepository<IBooking>
    {
        private readonly List<IBooking> models;

        public BookingRepository()
        {
            this.models = new List<IBooking>();
        }

        public void AddNew(IBooking model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IBooking> All() => this.models.AsReadOnly();

        public IBooking Select(string criteria)
        {
            return this.models.FirstOrDefault(b => b.BookingNumber == int.Parse(criteria));
        }
    }
}
