using Cars.Мodels.Interfaces;

namespace Cars
{
    public class Seat: ICar
    {
        private string model;
        private string color;

        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
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
            return $"{this.GetType().Name} {this.Color} {this.Model}";
        }
    }
}
