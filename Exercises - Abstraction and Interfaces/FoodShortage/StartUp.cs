

using FoodShortage.Core;
using FoodShortage.Core.Interfaces;
using FoodShortage.IO;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main()
        {
            IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
            engine.Run();
        }
    }
}
