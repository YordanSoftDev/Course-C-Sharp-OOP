

using BirthdayCelebrations.Core;
using BirthdayCelebrations.Core.Interfaces;
using BirthdayCelebrations.IO;

namespace BorderControl
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
