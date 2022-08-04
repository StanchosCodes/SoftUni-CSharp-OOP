using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] cmdArgs = command.Split(';', StringSplitOptions.RemoveEmptyEntries);

                    InputProcess(teams, cmdArgs);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine(Messages.NameNullOrWhiteSpace);
                }
            }
        }

        static void InputProcess(List<Team> teams, string[] cmdArgs)
        {
            string type = cmdArgs[0];
            string currTeamName = cmdArgs[1];

            if (type == "Team")
            {
                Team currNewTeam = new Team(currTeamName);
                teams.Add(currNewTeam);
            }
            else
            {
                Team currTeam = teams.FirstOrDefault(t => t.Name == currTeamName);

                if (currTeam == null)
                {
                    throw new InvalidOperationException(string.Format(Messages.NotExistingTeam, currTeamName));
                }

                if (type == "Add")
                {
                    string currPlayerName = cmdArgs[2];

                    Stats currPlayerStats = PlayerStats(cmdArgs.Skip(3).ToArray());
                    Player currPlayer = new Player(currPlayerName, currPlayerStats);

                    currTeam.AddPlayer(currPlayer);
                }
                else if (type == "Remove")
                {
                    string currPlayerName = cmdArgs[2];

                    currTeam.PlayerToRemove(currPlayerName);
                }
                else if (type == "Rating")
                {
                    Console.WriteLine(currTeam);
                }
            }
        }

        static Stats PlayerStats(string[] statsInfo)
        {
            int endurance = int.Parse(statsInfo[0]);
            int sprint = int.Parse(statsInfo[1]);
            int dribble = int.Parse(statsInfo[2]);
            int passing = int.Parse(statsInfo[3]);
            int shooting = int.Parse(statsInfo[4]);

            Stats newPlayerStats = new Stats(endurance, sprint, dribble, passing, shooting);

            return newPlayerStats;
        }
    }
}
