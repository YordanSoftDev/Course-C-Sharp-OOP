

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new(160, 8);
            car.Drive(200);
            Console.WriteLine(car.Fuel);
        }
    }
}
