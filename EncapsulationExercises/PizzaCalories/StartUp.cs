

using System.Xml;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main()
        {
            string pizza = Console.ReadLine();
            string[] pizzaData = pizza.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string pizzaName = pizzaData[1];
            string input = "";
            int toppingCount = 0;
            List<double> doughCalories = new();
            List<double> toppingCalories = new();
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputCharacteristics = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                try
                {



                    if (inputCharacteristics[0] == "Dough")
                    {
                        string flourType = inputCharacteristics[1];
                        string bakingTehnique = inputCharacteristics[2];
                        double weight = double.Parse(inputCharacteristics[3]);
                        Dough dough = new(flourType, bakingTehnique, weight);
                        doughCalories.Add(dough.CalculateCalories());
                    }
                    else
                    {
                        if (toppingCount > 10)
                        {
                            Console.WriteLine("Number of toppings should be in range [0..10].");
                            return;
                        }
                        string toppingType = inputCharacteristics[1];
                        double toppingWeight = double.Parse(inputCharacteristics[2]);
                        Topping topping = new(toppingType, toppingWeight);
                        toppingCalories.Add(topping.CalculateCalories());
                        toppingCount++;
                    }
                }
                catch (Exception ex )
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

            }
            double sumCalories = 0;
            if (doughCalories.Count > 0)
            {
                foreach (double calories in doughCalories)
                {
                    sumCalories += calories;
                }
            }
            if (toppingCalories.Count > 0)
            {
                foreach (double calories in toppingCalories)
                {
                    sumCalories += calories;
                }
            }
            Console.WriteLine($"{pizzaName} - {sumCalories:f2} Calories.");
        }
    }
}
