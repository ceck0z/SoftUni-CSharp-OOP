﻿namespace P01_Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }

        protected override double AdditionalConsumption => 0.9;
    }
}