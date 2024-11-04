


namespace Restaurant
{
    public class StartUp
    {
        static void Main()
        {
            Fish fish = new("Abi", 22);
            Food food = new("Meat", 10, 12);
            Console.WriteLine(fish.Grams);
        }
    }
}
