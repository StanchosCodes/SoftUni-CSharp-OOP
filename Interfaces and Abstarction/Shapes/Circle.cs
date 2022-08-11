using System;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            double radIn = radius - 0.4;
            double radOut = radius + 0.4;

            for (double y = radius; y >= -radius; y--)
            {
                for (double x = -radius; x < radOut; x += 0.5)
                {
                    double value = x * x + y * y;

                    if (value >= radIn * radIn && value <= radOut * radOut)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
