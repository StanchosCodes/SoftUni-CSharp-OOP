using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape circle = new Circle();
            IShape rectangle = new Rectangle();
            IShape square = new Square();

            GraphicEditor drawer = new GraphicEditor();

            drawer.DrawShape(circle);
            drawer.DrawShape(rectangle);
            drawer.DrawShape(square);
        }
    }
}
