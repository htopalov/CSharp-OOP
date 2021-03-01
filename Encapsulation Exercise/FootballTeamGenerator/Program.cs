using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teamsNames = new Dictionary<string, Team>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }
                string[] input = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                try
                {
                    if (command == "Add")
                    {
                        string teamName = input[1];
                        if (!teamsNames.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }
                        string playerName = input[2];
                        int endurance = int.Parse(input[3]);
                        int sprint = int.Parse(input[4]);
                        int dribble = int.Parse(input[5]);
                        int passing = int.Parse(input[6]);
                        int shooting = int.Parse(input[7]);
                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        teamsNames[teamName].AddPlayer(player);
                    }
                    else if (command == "Remove")
                    {
                        string teamName = input[1];
                        string playerName = input[2];
                        teamsNames[teamName].RemovePlayer(playerName);
                    }
                    else if (command == "Rating")
                    {
                        string teamName = input[1];
                        if (!teamsNames.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }
                        Console.WriteLine($"{teamName} - {teamsNames[teamName].AverageSkillTeam}");
                    }
                    else if (command == "Team")
                    {
                        string teamName = input[1];
                        Team team = new Team(teamName);
                        teamsNames.Add(teamName, team);
                    }
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
