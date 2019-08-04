using Restaurant.Foods;

namespace Restaurant.Starters
{
    public class Starter : Food
    {
        public Starter(string name, decimal price, double grams)
            : base(name, price, grams)
        {
        }
    }
}
