namespace P08_MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using P08_MilitaryElite.Contracts;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<IMission> missions;

        public Commando(string id, string firstname, string lastname, decimal salary, string corps) 
            : base(id, firstname, lastname, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions { get; private set; }

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine($"Missions:");

            foreach (var mis in this.missions)
            {
                sb.AppendLine($"  {mis.ToString().TrimEnd()}");
            }

            return sb.ToString()
                .TrimEnd();
        }
    }
}
