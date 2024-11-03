

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;

        public Pizza(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");

                this.name = value;
            }
        }
    }
}
