﻿namespace P03_WildFarm.Models.Animals.Entities
{
    using P03_WildFarm.Models.Foods.Entities;
    using System;
    using System.Collections.Generic;

    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override List<Type> PrefferedFoodTypes => new List<Type> { typeof(Meat) };

        protected override double WeightMultiplier => 0.40;

        public override string AskFood()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
