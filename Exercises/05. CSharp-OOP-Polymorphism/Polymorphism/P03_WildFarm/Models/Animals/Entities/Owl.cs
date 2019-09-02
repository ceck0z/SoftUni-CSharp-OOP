namespace P03_WildFarm.Models.Animals.Entities
{
    using P03_WildFarm.Models.Foods.Entities;
    using System;
    using System.Collections.Generic;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {

        }

        protected override List<Type> PrefferedFoodTypes => new List<Type> { typeof(Meat) };

        protected override double WeightMultiplier => 0.25;

        public override string AskFood()
        {
            return "Hoot Hoot";
        }
    }
}
