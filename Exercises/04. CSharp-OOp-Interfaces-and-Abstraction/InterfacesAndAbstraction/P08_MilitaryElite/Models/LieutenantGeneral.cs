using System.Collections.Generic;
using System.Text;
using P08_MilitaryElite.Contracts;

namespace P08_MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly List<ISoldier> privates;

        public LieutenantGeneral(string id, string firstname, string lastname, decimal salary) 
            : base(id, firstname, lastname, salary)
        {
            this.privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates => this.privates;

        public void AddPrivate(ISoldier @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine("Privates:");

            foreach (var pr in this.Privates)
            {
                sb.AppendLine($"  {pr.ToString().TrimEnd()}");
            }

            return sb.ToString()
                .TrimEnd();
        }
    }
}
