using Shapes.Мodels.Interfaces;
using System;

namespace Shapes
{
    public class Triangle : IDrawable
    {
        private int height;
        public Triangle(int height)
        {
            this.Height = height;
        }
        public int Height { get; set; }
        public void Draw()
        {
            for (int i = 1; i <= this.Height; i++)
            {
                for (int j = 1; j <= this.Height - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= (2 * i) - 1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
