namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private List<IPilot> pilots;
        private List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (pilots.Any(x => x.Name == name))
            {
                return $"Pilot {name} is hired already";
            }
            else
            {
                var pilot = new Pilot(name);
                pilots.Add(pilot);
                return $"Pilot {name} hired";
            }
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(x=>x.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }
            else
            {
                var tank = new Tank(name, attackPoints, defensePoints);
                machines.Add(tank);

                return $"Tank {name} manufactured - attack: {tank.AttackPoints:F2}; defense: {tank.DefensePoints:f2}";
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(x => x.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }
            else
            {
                var fighter = new Fighter(name, attackPoints, defensePoints);
                machines.Add(fighter);

                return $"Fighter {name} manufactured - attack: {fighter.AttackPoints:f2}; defense: {fighter.DefensePoints:f2}; aggressive: ON";
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var machine = machines.FirstOrDefault(x => x.Name == selectedMachineName);
            var pilot = pilots.FirstOrDefault(x => x.Name == selectedPilotName);
            if (pilot == null)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }
            if (machine == null)
            {
                return $"Machine {selectedMachineName} could not be found";
            }
            if (machine != null && machine.Pilot != null)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }
            if (machine != null && pilot != null && machine.Pilot == null)
            {
                pilot.AddMachine(machine);
                machine.Pilot = pilot;
            }
            return $"Pilot {pilot.Name} engaged machine {machine.Name}";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attackingMachine = machines.FirstOrDefault(x => x.Name == attackingMachineName);
            var defendingMachine = machines.FirstOrDefault(x => x.Name == defendingMachineName);
            if (attackingMachine == null)
            {
                return $"Machine {attackingMachineName} could not be found";
            }
            if (defendingMachine == null)
            {
                return $"Machine {defendingMachineName} could not be found";
            }
            if (attackingMachine.HealthPoints > 0 && defendingMachine.HealthPoints > 0)
            {
                attackingMachine.Attack(defendingMachine);
            }
            else if (attackingMachine.HealthPoints == 0)
            {
                return $"Dead machine {attackingMachine.Name} cannot attack or be attacked";
            }
            else if (defendingMachine.HealthPoints == 0)
            {
                return $"Dead machine {defendingMachine.Name} cannot attack or be attacked";
            }

            return $"Machine {defendingMachine.Name} was attacked by machine {attackingMachine.Name} - current health: {defendingMachine.HealthPoints:f2}";

        }

        public string PilotReport(string pilotReporting)
        {
            return pilots.FirstOrDefault(x => x.Name == pilotReporting).Report();
        }

        public string MachineReport(string machineName)
        {
            return machines.FirstOrDefault(x => x.Name == machineName).ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var fighter = (IFighter)machines.FirstOrDefault(x => x.Name == fighterName);
            if (fighter == null)
            {
                return $"Machine {fighterName} could not be found";
            }
            else
            {
                fighter.ToggleAggressiveMode();
                return $"Fighter {fighterName} toggled aggressive mode";
            }
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var tank = (ITank)machines.FirstOrDefault(x => x.Name == tankName);
            if (tank == null)
            {
                return $"Machine {tankName} could not be found";
            }
            else
            {
                tank.ToggleDefenseMode();
                return $"Tank {tankName} toggled defense mode";
            }
        }
    }
}