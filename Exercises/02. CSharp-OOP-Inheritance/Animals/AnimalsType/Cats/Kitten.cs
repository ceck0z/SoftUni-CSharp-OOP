﻿namespace Animals.AnimalsType.Cats
{
    public class Kitten : Cat
    {

        private const string kittenGender = "Female";

        public Kitten(string name, int age) 
            : base(name, age, kittenGender)
        {
        }

        public override string MakeNoise()
        {
            return "Meow";
        }
    }
}
