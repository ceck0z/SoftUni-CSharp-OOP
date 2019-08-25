
namespace P08_MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using P08_MilitaryElite.Contracts;

    public class Engineer : SpecialisedSoldier, IEngineer
    {

        private readonly List<IRepair> repairs;

        public Engineer(string id, string firstname, string lastname, decimal salary, string corps) 
            : base(id, firstname, lastname, salary, corps)
        {
           this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs { get; private set; }

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine($"Repairs:");

            foreach (var rep in this.repairs)
            {
                sb.AppendLine($"  {rep.ToString().TrimEnd()}");
            }

            return sb.ToString()
                .TrimEnd();
        }
    }
}
