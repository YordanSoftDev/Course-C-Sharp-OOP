using Cars.Мodels.Interfaces;

namespace Cars
{
    public class StartUp
    {
        static void Main()
        {
            ICar seat = new Seat("Cordoba", "Pink");
            ICar tesla = new Tesla("Model 3", "Grey", 2);

            Console.WriteLine(seat.ToString());
            Console.WriteLine(tesla.ToString());
        }
    }
}
