namespace P01_RawData
{
    public class EngineFactory
    {
        public Engine CreateEngine(int power,int speed)
        {
            return new Engine(power, speed);
        }
           
    }
}
