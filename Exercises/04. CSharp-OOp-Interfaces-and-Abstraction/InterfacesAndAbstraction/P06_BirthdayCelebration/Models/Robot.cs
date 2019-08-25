namespace P06_BirthdayCelebration.Models
{
    using P06_BirthdayCelebration.Contracts;

    class Robot : IIdentifiable
    {
        public Robot(string model,string id)
        {
            this.Model = model;

            this.Id = id;
        }

        public string Model { get; private set; }

        public string Id { get; private set; }
    }
}

