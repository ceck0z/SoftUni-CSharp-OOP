namespace P07_FoodShortage.Models
{
    using P07_FoodShortage.Contracts;

    class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            this.Model = model;

            this.Id = id;
        }

        public string Model { get; private set; }

        public string Id { get; private set; }
    }
}
