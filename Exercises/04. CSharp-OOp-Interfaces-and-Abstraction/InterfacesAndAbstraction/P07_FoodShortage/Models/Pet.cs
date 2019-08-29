namespace P07_FoodShortage.Models
{
    using P07_FoodShortage.Contracts;
    using System;

    public class Pet : IBirthdate
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;

            this.Birthdate = DateTime.ParseExact(birthdate, "dd/mm/yyyy", null);
        }

        public string Name { get; private set; }

        public DateTime Birthdate { get; private set; }
    }
}
