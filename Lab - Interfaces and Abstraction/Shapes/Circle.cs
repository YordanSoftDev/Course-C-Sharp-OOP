﻿using System;
using Shapes.Мodels.Interfaces;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;
        public Circle(int radius)
        {
            this.Radius = radius;
        }

        public int Radius { get; set; }

        public void Draw()
        {          
            double rIn = this.Radius - 0.4;
            double rOut = this.Radius + 0.4;

            for (double y = this.Radius; y >= -this.Radius; --y)
            {
                for (double x = -this.Radius; x <= this.Radius; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
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
