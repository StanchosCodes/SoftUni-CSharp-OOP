namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Decorations.Contracts;
    using Fish.Contracts;
    using Utilities.Messages;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }

        public int Comfort
        {
            get
            {
                int sum = 0;

                foreach (int decor in this.Decorations.Select(d => d.Comfort))
                {
                    sum += decor;
                }

                return sum;
            }
        }

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish;

        public void AddFish(IFish fish)
        {
            if (this.Capacity >= this.Fish.Count + 1)
            {
                this.Fish.Add(fish);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
        }

        public bool RemoveFish(IFish fish)
        {
            return this.Fish.Remove(fish);
        }

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }


        public void Feed()
        {
            foreach (IFish fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            if (this.Fish.Count > 0)
            {
                //"{aquariumName} ({aquariumType}):" +
                //    " Fish: {fishName1}, {fishName2}, {fishName3} (…) / none" +
                //    " Decorations: {decorationsCount}" +
                //    " Comfort: {aquariumComfort}"

                sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
                sb.AppendLine($"Fish: {string.Join(", ", this.Fish.Select(f => f.Name))}");
                sb.AppendLine($"Decorations: {this.Decorations.Count()}");
                sb.Append($"Comfort: {this.Comfort}");
            }
            else
            {
                sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
                sb.AppendLine($"Fish: none");
                sb.AppendLine($"Decorations: {this.Decorations.Count()}");
                sb.Append($"Comfort: {this.Comfort}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
