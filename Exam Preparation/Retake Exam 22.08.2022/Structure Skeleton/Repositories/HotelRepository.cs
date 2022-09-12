namespace BookingApp.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Hotels.Contacts;

    public class HotelRepository : IRepository<IHotel>
    {
        private readonly List<IHotel> models;

        public HotelRepository()
        {
            this.models = new List<IHotel>();
        }

        public void AddNew(IHotel model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IHotel> All() => this.models.AsReadOnly();

        public IHotel Select(string criteria)
        {
            return this.models.FirstOrDefault(h => h.FullName == criteria);
        }
    }
}
