
namespace Restaurant
{
    public class Beverages : Product
    {
        private double mililiters;
        public Beverages(string name, decimal price, double mililiters) : base(name, price)
        {
            this.Mililiters = mililiters;
        }
        public double Mililiters
        {
            get { return this.mililiters; }
            protected set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("The drink's mililiters cannot be zero or negative.");

                this.mililiters = value;
            }
        }
    }
}

