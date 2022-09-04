namespace AquaShop.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Models.Fish;
    using Repositories;
    using Models.Aquariums;
    using Models.Decorations;
    using Utilities.Messages;
    using Models.Aquariums.Contracts;
    using Models.Decorations.Contracts;



    public class Controller : IController
    {
        private readonly DecorationRepository decorations;
        private readonly ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                this.aquariums.Add(new FreshwaterAquarium(aquariumName));
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                this.aquariums.Add(new SaltwaterAquarium(aquariumName));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);

        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                this.decorations.Add(new Ornament());
            }
            else if (decorationType == "Plant")
            {
                this.decorations.Add(new Plant());
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration currDecoration = this.decorations.FindByType(decorationType);

            if (this.decorations.FindByType(decorationType) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            else
            {
                this.aquariums.First(a => a.Name == aquariumName).AddDecoration(currDecoration);

                this.decorations.Remove(currDecoration);

                return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
            }
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType == "FreshwaterFish")
            {
                if (this.aquariums.First(a => a.Name == aquariumName).GetType() == typeof(FreshwaterAquarium))
                {
                    this.aquariums.First(a => a.Name == aquariumName).AddFish(new FreshwaterFish(fishName, fishSpecies, price));

                    return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                }
                else
                {
                    return OutputMessages.UnsuitableWater;
                }
            }
            else if (fishType == "SaltwaterFish")
            {
                if (this.aquariums.First(a => a.Name == aquariumName).GetType() == typeof(SaltwaterAquarium))
                {
                    this.aquariums.First(a => a.Name == aquariumName).AddFish(new SaltwaterFish(fishName, fishSpecies, price));

                    return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                }
                else
                {
                    return OutputMessages.UnsuitableWater;
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
        }

        public string FeedFish(string aquariumName)
        {
            this.aquariums.First(a => a.Name == aquariumName).Feed();

            int fishCount = this.aquariums.First(a => a.Name == aquariumName).Fish.Count();
            return String.Format(OutputMessages.FishFed, fishCount);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium currAquarium = this.aquariums.First(a => a.Name == aquariumName);

            decimal fishsPriceSum = currAquarium.Fish.Sum(f => f.Price);
            decimal decorPriceSum = currAquarium.Decorations.Sum(d => d.Price);
            decimal totalAquariumPriceSum = Math.Round(fishsPriceSum + decorPriceSum, 2);

            return String.Format(OutputMessages.AquariumValue, aquariumName, totalAquariumPriceSum);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IAquarium aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().Trim();
        }
    }
}
