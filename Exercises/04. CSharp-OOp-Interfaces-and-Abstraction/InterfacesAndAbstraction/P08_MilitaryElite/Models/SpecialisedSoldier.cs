namespace P08_MilitaryElite.Models
{
    using P08_MilitaryElite.Enumerations;
    using P08_MilitaryElite.Exceptions;
    using System;

    using P08_MilitaryElite.Contracts;
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstname, string lastname, decimal salary,string corps)
            : base(id, firstname, lastname, salary)
        {
            ParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private void ParseCorps(string corpsStr)
        {
            Corps corps;

            bool parsed = Enum.TryParse<Corps>(corpsStr,out corps);

            if (!parsed)
            {
                throw new InvalidCorpsException();
            }

            this.Corps = corps;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {this.Corps}";
        }
    }
}
