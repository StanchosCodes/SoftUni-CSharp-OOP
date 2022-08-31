namespace INStock.Models
{
    using Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductStock : IProductStock
    {
        public ProductStock()
        {
            this.Products = new List<IProduct>();
        }

        private List<IProduct> Products { get; set; }
        public IProduct this[int index]
        {
            get
            {
                return this.Products[index];
            }
            set
            {
                this.Products[index] = value;
            }
        }

        public int Count
            => this.Products.Count;

        public void Add(IProduct product)
        {
            this.Products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            bool isContained = this.Products.Contains(product);

            return isContained;
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= this.Products.Count)
            {
                throw new IndexOutOfRangeException();
            }
            IProduct foundProduct = this.Products[index];

            return foundProduct;
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            List<IProduct> productsByPrice = this.Products.FindAll(p => p.Price == (decimal)price);

            return productsByPrice;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            List<IProduct> productsByQuantity = this.Products.FindAll(p => p.Quantity == quantity);

            return productsByQuantity;
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            List<IProduct> productsByPriceRange = this.Products
                .FindAll(p => p.Price >= (decimal)lo && p.Price <= (decimal)hi)
                .OrderByDescending(p => p.Price).ToList();

            return productsByPriceRange;
        }

        public IProduct FindByLabel(string label)
        {
            IProduct foundProduct = this.Products.FirstOrDefault(p => p.Label == label);

            if (foundProduct == null)
            {
                throw new ArgumentException();
            }

            return foundProduct;
        }

        public IProduct FindMostExpensiveProduct()
        {
            decimal theHighestProductPrice = this.Products.Max(p => p.Price);
            IProduct theMostExpensiveProduct = this.Products.First(p => p.Price == theHighestProductPrice);

            return theMostExpensiveProduct;
        }

        public bool Remove(IProduct product)
        {
            bool isRemoved = this.Products.Remove(product);

            return isRemoved;
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (IProduct product in this.Products)
            {
                yield return product;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
