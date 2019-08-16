namespace P04_PizzaCalories.Models
{
    using System.Collections.Generic;

    public class Pizza
    {
        private string name;

        private Dough dough;

        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
           
        }

        public string Name
        {
            get;
            set;
        }
    }
}
