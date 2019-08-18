namespace P04_PizzaCalories.Models
{
    using P04_PizzaCalories.Exceptions;
    using System;

    public class Topping
    {
        private const double MinWeight = 1;
        private const double MaxWeight = 50;

        private const double meat = 1.2;
        private const double veggies = 0.8;
        private const double cheese = 1.1;
        private const double sauce = 0.9;

        private double weight;
        private string name;

        public Topping(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if(value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidToppingNameException, value));
                }

                this.name = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if( value > MaxWeight || value < MinWeight)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidToppingWeightException,name,MinWeight,MaxWeight));
                }

                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            double calories = 0;

            switch (name.ToLower())
            {
                case "meat": calories = 2 * this.Weight * meat;
                    break;
                case "veggies": calories = 2 * this.Weight * veggies;
                    break;
                case "cheese": calories = 2 * this.Weight * cheese;
                    break;
                case "sauce": calories = 2 * this.Weight * sauce;
                    break;                   
                default:
                    break;
            }

            return calories;
        }
    }
}
