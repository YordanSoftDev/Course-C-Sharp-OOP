using BorderControl.Core;
using BorderControl.Core.Interfaces;
using BorderControl.IO;

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
