
namespace Restaurant
{
    public class Food : Product
    {
        public virtual double Grams { get; protected set; }
        public Food(string name, decimal price, double grams) : base(name, price)
        {
            this.Grams = grams;
        }
    }
}
