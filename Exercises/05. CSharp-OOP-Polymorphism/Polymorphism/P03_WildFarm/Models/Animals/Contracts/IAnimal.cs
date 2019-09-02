namespace P03_WildFarm.Models.Animals.Contracts
{
    using P03_WildFarm.Models.Foods.Contracts;

    public interface IAnimal
    {
        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }

        string AskFood();

        void Feed(IFood food);
    }
}
