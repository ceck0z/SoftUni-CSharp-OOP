using P08_MilitaryElite.Contracts;

namespace P08_MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstname, string lastname,decimal salary) 
            : base(id, firstname, lastname)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"Salary: {this.Salary:f2}";
        }
    }
}
