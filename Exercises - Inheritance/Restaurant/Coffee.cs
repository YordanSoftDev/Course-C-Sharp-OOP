
namespace Restaurant
{
    public class Coffee : HotBeverages
    {
        private const double CoffeeMilliliters = 50;
        private const decimal CoffeePrice = 3.50M;
        private decimal caffeine;
        public Coffee(string name, double caffeine) : base(name, CoffeePrice, CoffeeMilliliters)
        {
            this.Price = CoffeePrice;
            this.Mililiters = CoffeeMilliliters;
        }
        public double Caffeine { get; set; }
    }
}
