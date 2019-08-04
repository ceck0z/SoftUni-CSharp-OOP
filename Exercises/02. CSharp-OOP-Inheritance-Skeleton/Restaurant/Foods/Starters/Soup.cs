namespace Restaurant
{
    using Restaurant.Starters;

    public class Soup : Starter
    {
        public Soup(string name, decimal price, double grams)
            : base(name, price, grams)
        {
        }
    }
}
