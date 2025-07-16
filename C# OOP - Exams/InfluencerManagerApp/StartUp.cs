using InfluencerManagerApp.Core;
using InfluencerManagerApp.Core.Contracts;

public class StartUp
{
    static void Main()
    {      
        IEngine engine = new Engine();
        engine.Run();
    }
}
