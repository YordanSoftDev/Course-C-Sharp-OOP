

namespace ShoppingSpree
{
    public class Person
    {
        public string name;
        public decimal money;
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.BagOfProducts = new();
        }

        public string Name {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Name cannot be empty.");

                this.name = value;
            }
        }
        public decimal Money {
            get { return this.money; }
            private set
            {
                if (value < 0)
                    throw new ArgumentNullException("Money cannot be negative.");

                this.money = value;
            }
        }
        public List<Product> BagOfProducts { get; set; }

        public void AddProduct(Product product, Person person)
        {
            BagOfProducts.Add(product);
            person.Money -= product.Cost;
        }
        public void Print(Person person, string product)
        {
            Console.WriteLine($"{person.Name} bought {product}");
        }
    }
}
