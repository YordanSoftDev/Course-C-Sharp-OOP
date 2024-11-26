
using FoodShortage.Core.Interfaces;
using FoodShortage.IO.Interfaces;
using FoodShortage.Мodels;
using FoodShortage.Мodels.Interfaces;
using System.Xml.Linq;


namespace FoodShortage

    .Core;
public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        int number = int.Parse(Console.ReadLine());
        List<IBuyer> buyers = new();
        string buyerName = "";

        for (int i = 0; i < number; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length == 4)
            {
                string personName = tokens[0];
                int age = int.Parse(tokens[1]);
                double id = double.Parse(tokens[2]);
                DateTime birthdate = DateTime.Parse(tokens[3]);
                try
                {
                    IBuyer buyer = new Citizen(personName, age, id, birthdate);
                    buyers.Add(buyer);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (tokens.Length == 3)
            {
                string rebelName = tokens[0];
                int rebelAge = int.Parse(tokens[1]);
                string rebelGroup = tokens[1];
                try
                {
                    IBuyer buyer = new Rebel(rebelName, rebelAge, rebelGroup);
                    buyers.Add(buyer);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        int purchasedFood = 0;
        while ((buyerName = reader.ReadLine()) != "End")
        {
            IBuyer buyerIncreasedFood = buyers.FirstOrDefault(buyer => buyer.Name.Equals(buyerName,
                StringComparison.OrdinalIgnoreCase));
            if(buyerIncreasedFood != null)
            {
                buyerIncreasedFood.BuyFood();
                Type type = buyerIncreasedFood?.GetType();
                if (type.Name == nameof(Citizen))
                {
                    buyerIncreasedFood.BuyFood();
                    purchasedFood += 10;
                }
                else
                {
                    buyerIncreasedFood.BuyFood();
                    purchasedFood += 5;
                }
            }
        }
        
        writer.WriteLine(string.Join("\n", purchasedFood));        
    }
}