namespace P01_RawData
{
    using System.Collections.Generic;

    public class CarCatalog
    {
        private List<Car> cars;
        private EngineFactory engineFactory;
        private CargoFactory cargoFactory;
        private TireFactory tireFactory;
        private const int tiresCount = 4;

        public CarCatalog(EngineFactory engineFactory,CargoFactory cargoFactory,TireFactory tireFactory)
        {
            this.cars = new List<Car>();
            this.engineFactory = engineFactory;
            this.cargoFactory = cargoFactory;
            this.tireFactory = tireFactory;
        }

        public void Add(string[] parameters)
        {
            string model = parameters[0];
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];

            Engine engine = engineFactory.CreateEngine(engineSpeed, enginePower);
            Cargo cargo = cargoFactory.CreateCargo(cargoWeight, cargoType);
            Tire[] tires = new Tire[tiresCount];

            int tireIndex = 0;

            for (int j = 5; j <= 12; j += 2)
            {
                double tirePressure = double.Parse(parameters[j]);

                int tireAge = int.Parse(parameters[j + 1]);

                Tire tire = tireFactory.addTires(tirePressure,tireAge);

                tires[tireIndex] = tire;

                tireIndex++;

            }

            Car car = new Car(model, engine, cargo, tires);

            cars.Add(car);
        }

        public List<Car> getCars()
        {
            return this.cars;
        }
    }
}
