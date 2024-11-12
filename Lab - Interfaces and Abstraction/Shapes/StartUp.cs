using System;
using System.Collections.Generic;
using Shapes.Мodels.Interfaces;

namespace Shapes
{
    public class StartUp
    {
        static void Main()
        {
            int radius = int.Parse(Console.ReadLine());
            IDrawable circle = new Circle(radius);

            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            IDrawable rectangle = new Rectangle(width, height);

            int triangleHeight = int.Parse(Console.ReadLine());
            IDrawable triangle = new Triangle(height);

            Console.WriteLine("$This is a circle of stars."); 
            circle.Draw();
            Console.WriteLine("$This is a rectangle of stars.");
            rectangle.Draw();
            Console.WriteLine("$This is a triangle of stars.");
            triangle.Draw();

            List<IDrawable> typesOfShapes = new()
            {
                circle, rectangle, triangle,
            };
            DrawShapes(typesOfShapes);
        }

        static void DrawShapes(List<IDrawable> shapes)
        {
            Console.WriteLine("I draw figures from different types.");
            foreach (IDrawable shape in shapes)
            {
                shape.Draw();
            }
        }
    }
}
