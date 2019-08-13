﻿using P05_FootballTeamGenerator.Exceptions;
using System;

namespace P05_FootballTeamGenerator.Models
{
    public class Stat
    {
        private const int MinStatValue = 0;
        private const int MaxStatValue = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stat(int endurance, int spirint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                ValidateStat(value, nameof(this.endurance));

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                ValidateStat(value, nameof(this.sprint));

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                ValidateStat(value, nameof(this.dribble));

                this.dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                ValidateStat(value, nameof(this.passing));

                this.passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                ValidateStat(value, nameof(this.shooting));

                this.shooting = value;
            }
        }

        private void ValidateStat(int value,string name)
        {
            if (value < MinStatValue || value > MaxStatValue)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidStatException, name, MinStatValue, MaxStatValue));
            }
        }

        public double OverallStat => ((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0);
    }

}
