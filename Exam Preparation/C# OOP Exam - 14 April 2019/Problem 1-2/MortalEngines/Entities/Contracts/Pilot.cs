﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Contracts
{
    public class Pilot : IPilot
    {
        private string name;
        private List<IMachine> machines;

        public Pilot(string name)
        {
            this.machines = new List<IMachine>();
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }
                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }

            machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} - {this.machines.Count} machines");
            foreach (var machine in machines)
            {
                sb.AppendLine(machine.ToString());  
            }

            return sb.ToString().Trim();
        }
    }
}
