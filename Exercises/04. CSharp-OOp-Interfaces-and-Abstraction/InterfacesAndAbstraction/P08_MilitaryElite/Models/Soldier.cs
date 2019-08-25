using P08_MilitaryElite.Contracts;

namespace P08_MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        public Soldier(string id, string firstname, string lastname)
        {
            this.Id = id;
            this.FirstName = firstname;
            this.LastName = lastname;
        }

        public string Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} ";
        }
    }
}
