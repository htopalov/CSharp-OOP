using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(string id,string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string Id { get; }

        public string FirstName { get; }

        public string LastName { get; }
        public override string ToString()
        {
            return $"Name: {this.FirstName} {LastName} Id: {this.Id}";
        }
    }
}
