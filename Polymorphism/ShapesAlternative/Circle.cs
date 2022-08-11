using System;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public double Radius { get; private set; }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(this.Radius, 2);
        }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();

            double radIn = this.Radius - 0.4;
            double radOut = this.Radius + 0.4;

            for (double y = this.Radius; y >= -this.Radius; y--)
            {
                for (double x = -this.Radius; x < radOut; x += 0.5)
                {
                    double value = x * x + y * y;

                    if (value >= radIn * radIn && value <= radOut * radOut)
                    {
                        sb.Append("*");
                    }
                    else
                    {
                        sb.Append(" ");
                    }
                }
                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }
    }
}
