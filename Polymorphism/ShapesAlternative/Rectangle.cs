using System;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height { get; private set; }
        public double Width { get; private set; }

        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return (this.Height + this.Width) * 2;
        }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();
            string currLine = string.Empty;

            currLine = DrawLine(this.Width, '*', '*');
            sb.Append(currLine);

            for (int i = 1; i < this.Height - 1; i++)
            {
                currLine = DrawLine(this.Width, '*', ' ');
                sb.Append(currLine);
            }
            currLine = DrawLine(this.Width, '*', '*');
            sb.Append(currLine);

            return sb.ToString().TrimEnd();
        }

        private string DrawLine(double width, char end, char mid)
        {
            StringBuilder sb = new StringBuilder();

           sb.Append(end);

            for (int i = 1; i < width - 1; i++)
            {
                sb.Append(mid);
            }
            sb.AppendLine(end.ToString());

            return sb.ToString();
        }
    }
}
