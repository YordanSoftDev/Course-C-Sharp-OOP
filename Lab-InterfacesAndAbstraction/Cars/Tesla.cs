using Cars.Мodels.Interfaces;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        private string model;
        private string color;
        private int battery;

        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("The car has to have a model.");

                this.model = value;
            }
        }
        public string Color
        {
            get { return this.color; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("The car has to have a color.");

                this.color = value;
            }
        }
        public int Battery
        {
            get { return this.battery; }
            private set
            {
                if (value <= 0 || value > 3)
                    throw new ArgumentOutOfRangeException("The count of batteries cannot be zero, negative or " +
                        "bigger than 3.");

                this.battery = value;
            }
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} {this.Color} {this.Model} with {this.Battery} batteries.";
        }
    }
}
