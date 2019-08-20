namespace P03_Ferrari.Models
{
    using P03_Ferrari.Contracts;

    public class Ferrari : ICar
    {

        private static string carName = "Ferrari";
        private static string carModel = "488-Spider";

        public Ferrari(string driver)
        {
            this.CarName = carName;
            this.CarModel = carModel;
            this.Driver = driver;
        }

        public string CarName { get; private set; }

        public string CarModel { get; private set; }

        public string Driver { get; set; }

        public string PushTheGasPedal()
        {
            return "Gas!";
        }

        public string UseBrakes()
        {
           return "Brakes!";
        }

        
    }
}
