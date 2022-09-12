namespace BookingApp.Repositories
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Models.Rooms.Contracts;
    using System.Linq;

    public class RoomRepository : IRepository<IRoom>
    {
        private readonly List<IRoom> models;

        public RoomRepository()
        {
            this.models = new List<IRoom>();
        }

        public void AddNew(IRoom model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IRoom> All() => this.models.AsReadOnly();

        public IRoom Select(string criteria)
        {
            return this.models.FirstOrDefault(r => r.GetType().Name == criteria);
        }
    }
}
