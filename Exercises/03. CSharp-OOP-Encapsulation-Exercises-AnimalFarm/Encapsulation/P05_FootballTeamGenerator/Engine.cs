
namespace P05_FootballTeamGenerator
{
    using P05_FootballTeamGenerator.Exceptions;
    using P05_FootballTeamGenerator.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private List<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {

                try
                {
                    string[] commandTokens = command.Split(";")
                        .ToArray();

                    string cmdType = commandTokens[0];
                    string teamName = commandTokens[1];

                    if (cmdType == "Team")
                    {
                        Team team = new Team(teamName);

                        this.teams.Add(team);
                    }

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                command = Console.ReadLine();
            }
        }

        private void ValidateTeamName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingTeamException, name));
            }
        }
    }
}
