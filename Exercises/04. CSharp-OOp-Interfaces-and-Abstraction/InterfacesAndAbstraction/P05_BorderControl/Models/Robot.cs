namespace P05_BorderControl.Models
{
    using P05_BorderControl.Contracts;

    public class Robot : IIdentifiable
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
