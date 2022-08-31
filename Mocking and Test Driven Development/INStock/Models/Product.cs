namespace INStock.Models
{
    using Contracts;
    using System.Diagnostics.CodeAnalysis;

    public class Product : IProduct
    {
        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Label { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int CompareTo([AllowNull] IProduct other)
        {
            if (this.Label == other.Label)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
