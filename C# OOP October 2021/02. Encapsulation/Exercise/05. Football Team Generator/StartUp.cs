namespace _05.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            string line;

            while ((line = Console.ReadLine()) != "END")
            {
                string[] dataArgs = line.Split(';');

                string command = dataArgs[0];
                string teamName = dataArgs[1];

                try
                {
                    switch (command)
                    {
                        case "Team":
                            teams.Add(teamName, new Team(teamName));
                            break;

                        case "Add" when IsTeamExists(teams, teamName) == true:
                            //CheckIsTeamExists(teams, teamName);
                            Player playerToAdd = CreatePlayer(dataArgs[2..]);
                            teams[teamName].AddPlayer(playerToAdd);
                            break;

                        case "Remove" when IsTeamExists(teams, teamName) == true:
                            string playerName = dataArgs[2];

                            //CheckIsTeamExists(teams, teamName);
                            teams[teamName].RemovePlayer(playerName);                            
                            break;

                        case "Rating" when IsTeamExists(teams, teamName) == true:
                            //CheckIsTeamExists(teams, teamName);
                            Console.WriteLine(teams[teamName]);
                            break;

                        default:
                            Console.WriteLine($"Team {teamName} does not exist.");
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

            }

        }

        private static Player CreatePlayer(string[] playerData)
        {
            string name = playerData[0];
            int endurance = int.Parse(playerData[1]);
            int sprint = int.Parse(playerData[2]);
            int dribble = int.Parse(playerData[3]);
            int passing = int.Parse(playerData[4]);
            int shoting = int.Parse(playerData[5]);

            return new Player(name, endurance,sprint,dribble,passing,shoting);
        }

        private static bool IsTeamExists(Dictionary<string, Team> teams, string teamName)
            => teams.ContainsKey(teamName);
        //{
        //    //if (!teams.ContainsKey(teamName))
        //    //{
        //    //   throw new ArgumentException($"Team {teamName} does not exist.");                
        //    //}
        //}

    }
}
