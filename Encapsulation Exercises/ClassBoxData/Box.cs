
using System.Threading.Channels;

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
            get { return this.length; }
            private set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("Length cannot not be zero or negative number.");

                this.length = value;
            }
        }

        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("Width cannot not be zero or negative number.");

                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("Height cannot not be zero or negative number.");

                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            return (2 * length * width) + (2 * length * height) + (2 * width * height);
        }

        public double LateralSurfaceArea()
        {
            return (2 * length * height) + (2 * width * height);
        }
        public double Volume()
        {
            return length * width * height;
        }

        public void Print()
        {
            Console.WriteLine($"Surface Area - {this.SurfaceArea():f2} {Environment.NewLine}" +
                $"Lateral Surface Area - {this.LateralSurfaceArea():f2} {Environment.NewLine}" +
                $"Volume - {this.Volume():f2}");
        }
    }
}
