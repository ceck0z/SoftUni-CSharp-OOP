﻿namespace P05_BorderControl.Models
{
    using P05_BorderControl.Contracts;

    public class Citizen : IIdentifiable
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;

            this.Age = age;

            this.Id = id;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }
    }    
}
