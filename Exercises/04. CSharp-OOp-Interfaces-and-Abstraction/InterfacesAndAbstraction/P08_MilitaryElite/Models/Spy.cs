namespace P08_MilitaryElite.Models
{
    using P08_MilitaryElite.Contracts;
    using System;

    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstname, string lastname, int codeNumber) 
            : base(id, firstname, lastname)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            return base.ToString()
                .TrimEnd() + 
                Environment.NewLine +
                $"Code Number: {this.CodeNumber}";
        }
    }
}
