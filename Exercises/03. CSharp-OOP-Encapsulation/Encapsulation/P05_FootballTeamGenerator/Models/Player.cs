namespace P05_FootballTeamGenerator.Models
{
    using P05_FootballTeamGenerator.Exceptions;
    using System;

    public class Player
    {
        private string name;

        public Player(string name,Stat stat)
        {
            this.Name = name;
            this.Stat = stat;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyNameException);
                }

                this.name = value;
            }
        }

        public double OverallSkill => this.Stat.OverallStat;

        public Stat Stat { get; private set; }
    }
}
