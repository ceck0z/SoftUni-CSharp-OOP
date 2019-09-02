﻿namespace P03_WildFarm.Models.Animals.Entities
{
    using P03_WildFarm.Models.Foods.Entities;
    using System;
    using System.Collections.Generic;

    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override List<Type> PrefferedFoodTypes => new List<Type>
        {
            typeof(Vegetable),
            typeof(Fruit),
            typeof(Meat),
            typeof(Seeds)
        };

        protected override double WeightMultiplier => 0.35;

        public override string AskFood()
        {
            return "Cluck";
        }
    }
}
