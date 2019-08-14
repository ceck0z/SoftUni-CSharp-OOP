namespace P05_FootballTeamGenerator.Models
{
    using P05_FootballTeamGenerator.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;
        private List<Player> players;

        public Team()
        {
            this.players = new List<Player>();
        }

        public Team(string name)
            :this()
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.Name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyNameException);
                }

                this.Name = value;
            }
        }

        public int Rating => (int)Math.Round((this.players.Average(p=>p.OverallSkill)), 0);

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            Player playerToRemove = this.players.FirstOrDefault(p => p.Name == name);

            if (playerToRemove == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MissingPlayerException,name,this.Name));
            }

            this.players.Remove(playerToRemove);
;        }
    }
}
