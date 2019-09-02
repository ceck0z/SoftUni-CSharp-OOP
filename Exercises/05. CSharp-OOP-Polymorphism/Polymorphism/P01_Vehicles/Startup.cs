using P01_Vehicles.Core;

namespace P01_Vehicles
{
    public class Startup
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
