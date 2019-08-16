namespace P04_PizzaCalories.Models
{
    using P04_PizzaCalories.Exceptions;
    using System;

    public class Dough
    {
        private static int MinWeight = 1;
        private static int MaxWeight = 200;

        private static double White = 1.5;
        private static double Wholegrain = 1.0;
        private static double Crispy = 0.9;
        private static double Chewy = 1.1;
        private static double Homemade = 1.0;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return this.FlourType;
            }
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDoughTypeException);
                }

                this.FlourType = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.BakingTechnique;
            }
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDoughTypeException);
                }

                this.BakingTechnique = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.Weight;
            }
            private set
            {
                if (value < MinWeight || MaxWeight < value)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidDoughWeightException, MinWeight, MaxWeight));
                }

                this.Weight = value;
            }
        }

        public double CalculateCalories()
        {
            double calories = 0.0;

            switch (flourType.ToLower())
            {
                case "white":
                    switch (bakingTechnique.ToLower())
                    {
                        case "crispy": calories = 2 *this.Weight * White * Crispy;
                            break;
                        case "chewy": calories = 2 * this.Weight * White * Chewy;
                            break;
                        case "homemade": calories = 2 * this.Weight * White * Homemade;
                            break;
                        default:
                            break;
                    };
                    break;
                case "wholegrain":
                    switch (bakingTechnique.ToLower())
                    {
                        case "crispy":
                            calories = 2 * this.Weight * Wholegrain * Crispy;
                            break;
                        case "chewy":
                            calories = 2 * this.Weight * Wholegrain * Chewy;
                            break;
                        case "homemade":
                            calories = 2 * this.Weight * Wholegrain * Homemade;
                            break;
                        default:
                            break;

                    };
                    break;
                default:
                    break;
            }

            return calories;
        }

    }
}
