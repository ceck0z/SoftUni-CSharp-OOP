namespace P04_PizzaCalories.Models
{
    using P04_PizzaCalories.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private const int MinLenght = 1;
        private const int MaxLenght = 15;
        private const int MinToppingCount = 0;
        private const int MaxToppingCount = 10;

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;

            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if ( value.Length < MinLenght || value.Length > MaxLenght || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNameLenghtException,MinLenght,MaxLenght));
                }
                this.name = value;
            }
        }

        public Dough Dough
        {
            get;
            private set;
        }

        public void AddTopping(Topping topping)
        {
            if(this.toppings.Count < MinToppingCount || this.toppings.Count > MaxToppingCount)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfToppingsException,MinToppingCount,MaxToppingCount));
            }

            this.toppings.Add(topping);            
        }

        public override string ToString()
        {
            double calories = this.Dough.CalculateCalories() + this.toppings.Sum(x => x.CalculateCalories());

            return $"{this.Name} - {calories:F2} Calories."; 
        }
    }
}
