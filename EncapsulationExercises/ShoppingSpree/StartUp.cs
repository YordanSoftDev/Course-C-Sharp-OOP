
namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main()
        {
            List<string> peopleNamesAndMoney = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> productTypesAndPrice = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<Person> people = new();
            List<Product> products = new();

            for (int k = 0; k < peopleNamesAndMoney.Count; k++)
            {
                string[] personNameAndMoney = peopleNamesAndMoney[k].Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = personNameAndMoney[0];
                int money = int.Parse(personNameAndMoney[1]);
                Person person = new(name, money);
                people.Add(person);
            }

            for (int d = 0; d < productTypesAndPrice.Count; d++)
            {
                string[] productTypeAndPrice = productTypesAndPrice[d].Split("=", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                string productType = productTypeAndPrice[0];
                int productPrice = int.Parse(productTypeAndPrice[1]);
                Product product = new(productType, productPrice);
                products.Add(product);
            }

            string nameAndWishesProduct = "";
            while ((nameAndWishesProduct = Console.ReadLine()) != "END")
            {
                string[] buyerAndWishesProduct = nameAndWishesProduct.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string buyerName = buyerAndWishesProduct[0];
                string product = buyerAndWishesProduct[1];
                if (buyerName != null && buyerName != string.Empty)
                {
                    Person buyer = people.FirstOrDefault(p => p.Name == buyerName);
                    Product product1 = products.FirstOrDefault(p => p.Name == product);
                    if (buyer != null && product1 != null)
                    {
                        if (buyer.Money >= product1.Cost)
                        {
                            buyer.AddProduct(product1, buyer);
                            buyer.Print(buyer, product1.Name);
                        }
                        else
                            Console.WriteLine($"{buyer.Name} can't afford {product1.Name}");
                    }
                }
            }
            foreach (var person in people)
            {
                if (person.BagOfProducts.Count == 0)
                    Console.WriteLine($"{person.Name} - Nothing bought");
                else
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagOfProducts.Select(p => p.Name))}");
            }
        }
    }
}

