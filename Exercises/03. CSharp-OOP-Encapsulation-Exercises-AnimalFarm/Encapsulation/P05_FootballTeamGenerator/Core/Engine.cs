﻿
namespace P05_FootballTeamGenerator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using P05_FootballTeamGenerator.Exceptions;
    using P05_FootballTeamGenerator.Models;
    
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
                        AddTeam(teamName);
                    }
                    else if (cmdType == "Add")
                    {
                        AddPlayerToATeam(commandTokens, teamName);
                    }
                    else if (cmdType == "Remove")
                    {
                        RemovePlayerFromATeam(commandTokens, teamName);
                    }
                    else if (cmdType == "Rating")
                    {
                        RatingTeam(teamName);
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

        private void RatingTeam(string teamName)
        {
            ValidateTeamName(teamName);

            Team team = this.teams.First(t => t.Name == teamName);

            Console.WriteLine(team.ToString());
        }

        private void RemovePlayerFromATeam(string[] commandTokens, string teamName)
        {
            ValidateTeamName(teamName);

            string playerName = commandTokens[2];

            Team team = this.teams.First(t => t.Name == teamName);

            team.RemovePlayer(playerName);
        }

        private void AddPlayerToATeam(string[] commandTokens, string teamName)
        {
            ValidateTeamName(teamName);

            string playerName = commandTokens[2];
            Stat stat = CreateStat(commandTokens);

            Player player = new Player(playerName, stat);

            Team team = this.teams.FirstOrDefault(t => t.Name == teamName);
            
            team.AddPlayer(player);
        }

        private void AddTeam(string teamName)
        {
            Team team = new Team(teamName);

            this.teams.Add(team);
        }

        private static Stat CreateStat(string[] commandTokens)
        {
            int endurance = int.Parse(commandTokens[3]);
            int sprint = int.Parse(commandTokens[4]);
            int dribble = int.Parse(commandTokens[5]);
            int passing = int.Parse(commandTokens[6]);
            int shooting = int.Parse(commandTokens[7]);

            Stat stat = new Stat(endurance, sprint, dribble, passing, shooting);
            return stat;
        }

        private void ValidateTeamName(string name)
        {

            Team team = this.teams.FirstOrDefault(t => t.Name == name);

            if(team == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingTeamException, name));
            }

        }
    }
}
