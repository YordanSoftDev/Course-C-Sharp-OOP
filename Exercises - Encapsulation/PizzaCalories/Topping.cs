
using System.Xml.Linq;

namespace PizzaCalories
{
    public class Topping
    {
        private const int CaloriesPerGram = 2;
        private string toppingType;
        private double toppingWeight;
        public Topping(string toppingType, double toppingWeight)
        {
            this.ToppingType = toppingType;
            this.ToppingWeight = toppingWeight;
        }

        public string ToppingType
        {
            get { return toppingType; }
            set
            {
                string toppingValue = value.ToLower();
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Topping type is empty");
                else if (toppingValue != "meat" && toppingValue != "veggies" && toppingValue != "cheese"
                    && toppingValue != "sauce")
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");

                this.toppingType = value;
            }
        }

        public double ToppingWeight
        {
            get { return toppingWeight; }
            private set
            {
                if (value < 1 || value > 50)
                    throw new ArgumentException($"{toppingType} weight should be in the range [1..50].");

                toppingWeight = value;
            }
        }

        public readonly Dictionary<string, double> ToppingTypesModifiers = new()
            {
                {"meat", 1.2},
                {"veggies", 0.8},
                {"cheese", 1.1},
                {"sauce", 0.9}
            };
        public double CalculateCalories()
        {
            double calories = this.ToppingWeight * CaloriesPerGram * ToppingTypesModifiers[this.ToppingType.ToLower()];
            return double.Parse(calories.ToString("F2"));
        }
    }
}
