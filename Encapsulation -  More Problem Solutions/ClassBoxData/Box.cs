using System;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                    // throw new ArgumentException(String.Format(ZeroOrNegativeArgumentException, nameof(this.Length)));
                    // String.Format замества place holder - a с nameof(this.Lenght) -> работи ако примерно имаме константа тип стринг която  искаме да слагаме на много места но има част от него която трябва да с променя динамино спрямо местото където е
                    // private const string ZeroOrNegativeArgumentException = "{0} cannot be zero or negative.";
                }

                this.length = value;
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                }

                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
                    // nameof returns the name of the given variable -> in this case is "Height"
                }

                this.height = value;
            }
        }

        public double SurfaceArea()
            => (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);

        public double LateralSurfaceArea()
            => (2 * this.Length * this.Height) + (2 * this.Width * this.Height);

        public double Volume()
            => this.Length * this.Width * this.Height;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {this.SurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}");
            sb.Append($"Volume - {this.Volume():f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
