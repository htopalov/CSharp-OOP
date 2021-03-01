using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public int Endurance
        {
            get { return endurance; }
            private set { this.endurance = IsValid(value, nameof(Endurance)); }
        }
        public int Sprint
        {
            get { return sprint; }
            private set { this.sprint = IsValid(value, nameof(Sprint)); }
        }
        public int Dribble
        {
            get { return dribble; }
            private set {this. dribble = IsValid(value, nameof(Dribble)); }
        }
        public int Passing
        {
            get { return passing; }
            private set { this. passing = IsValid(value, nameof(Passing)); }
        }
        public int Shooting
        {
            get { return shooting; }
            private set {this.shooting = IsValid(value, nameof(Shooting)); }
        }
        public double Skill
        {
            get { return Math.Round((this.Endurance + this.Sprint+this.Dribble + this.Passing + this.Shooting)/ 5.0); }
        }
        private int IsValid(int value, string statName)
        {
            if (value >= 0 && value <= 100)
            {
                return value;
            }
            else
            {
                throw new ArgumentException($"{statName} should be between 0 and 100.");
            }
        }

    }
}
