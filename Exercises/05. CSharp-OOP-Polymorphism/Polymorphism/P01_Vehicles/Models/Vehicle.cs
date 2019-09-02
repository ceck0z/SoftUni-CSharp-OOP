namespace P01_Vehicles.Models
{
    using P01_Vehicles.Models.Cars.Contracts;

    public abstract class Vehicle : IVehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;

            this.FuelConsumption = fuelConsumption;

        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        protected abstract double AdditionalConsumption { get; }

        public string Drive(double distance)
        {
            double requiredFuel = (FuelConsumption + AdditionalConsumption) * distance;

            if (requiredFuel <= FuelQuantity)
            {
                FuelQuantity -= requiredFuel;

                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
            
        }

        public virtual void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
