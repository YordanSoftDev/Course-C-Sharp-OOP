
namespace PizzaCalories
{
    public class Dough
    {
        private const double WhiteDoughModifier = 1.5;
        private const double WholegrainDoughModifier = 1.0;
        private const double CrispyTehniqueModifier = 0.9;
        private const double ChewyTehniqueModifier = 1.1;
        private const double HomemadeTehniqueModifier = 1.0;

        private const int CaloriesPerGram = 2;

        private string flourType;
        private string bakingTehnique;
        private double doughWeight;
        public Dough(string flourType, string bakingTehnique, double doughWeight)
        {
            this.FlourType = flourType;
            this.BakingTehnique = bakingTehnique;
            this.DoughWieght = doughWeight;
        }

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Flour Type cannot be empty.");
                else if (value != "White" && value != "Wholegrain")
                    throw new ArgumentException("Invalid type of dough.");

                flourType = value;
            }
        }
        public string BakingTehnique
        {
            get { return bakingTehnique; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Baking Tehnique cannot be empty.");
                else if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                    throw new ArgumentException("Invalid type of dough.");

                bakingTehnique = value;
            }
        }
        public double DoughWieght
        {
            get { return doughWeight; }
            private set
            {
                if (value < 1 || value > 200)
                    throw new ArgumentException("Dough should be in the range [1..200].");

                doughWeight = value;
            }
        }

        private readonly Dictionary<string, double> FlourTypeModifiers = new()
        {
            { "white", 1.5 },
            { "wholegrain", 1.0 }
        };

        private readonly Dictionary<string, double> BakingTehniqueModifiers = new()
        {
            { "crispy", 0.9 },
            { "chewy", 1.1 },
            { "homemade", 1.0 }
        };
        public double CalculateCalories()
        {
            double flourTypeModifier = FlourTypeModifiers[this.FlourType.ToLower()];
            double bakingTehniqueModifier = BakingTehniqueModifiers[this.BakingTehnique.ToLower()];
            return Math.Round(CaloriesPerGram * this.DoughWieght * flourTypeModifier * bakingTehniqueModifier, 2);
        }
    }
}
