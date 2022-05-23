using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 0; i < teamsCount; i++)
            {
                RegisterTeams(teams);
            }

            string line = Console.ReadLine();

            while (line != "end of assignment")
            {
                AssignMembers(teams, line);

                line = Console.ReadLine();
            }

            List<Team> teamsToDisband = teams
                .Where(t => t.Members.Count == 0)
                .OrderBy(t => t.Name)                
                .ToList();

            List<Team> validTeams = teams
                .Where(t => t.Members.Count > 0)
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.Name)
                .ToList();

            PrintValidTeams(validTeams);
            //Console.WriteLine(string.Join(Environment.NewLine, validTeams));            
            Console.WriteLine("Teams to disband:");            
            PrintDisbandTeams(teamsToDisband);

            //teamsToDisband
            //    .ForEach(t => Console.WriteLine(t.Name));
        }

        private static void PrintValidTeams(List<Team> validTeams)
        {
            foreach (var team in validTeams)
            {
                Console.WriteLine(team.Name);
                Console.WriteLine($"- {team.Creator}");

                foreach (var member in team.Members.OrderBy(m => m))
                {
                    Console.WriteLine($"-- {member}");
                }
            }
        }

        private static void PrintDisbandTeams(List<Team> teamsToDisband)
        {
            foreach (var team in teamsToDisband)
            {
                Console.WriteLine(team.Name);
            }
        }

        private static void AssignMembers(List<Team> teams, string line)
        {
            string[] memberData = line.Split("->", StringSplitOptions.RemoveEmptyEntries);

            string memberName = memberData[0];
            string teamToJoin = memberData[1];

            if (!IsTeamExist(teams, teamToJoin))
            {
                Console.WriteLine($"Team {teamToJoin} does not exist!");
            }
            else if (IsMemberExist(teams, memberName) || IsCreatorExist(teams, memberName))
            {
                Console.WriteLine($"Member {memberName} cannot join team {teamToJoin}!");
            }
            else
            {
                Team currentTeam = teams.FirstOrDefault(t => t.Name == teamToJoin);
                currentTeam.Members.Add(memberName);
            }
        }

        private static void RegisterTeams(List<Team> teams)
        {
            string[] teamData = Console.ReadLine()
                .Split('-', StringSplitOptions.RemoveEmptyEntries);

            string creator = teamData[0];
            string teamName = teamData[1];

            if (IsCreatorExist(teams, creator))
            {
                Console.WriteLine($"{creator} cannot create another team!");
            }
            else if (IsTeamExist(teams, teamName))
            {
                Console.WriteLine($"Team {teamName} was already created!");
            }
            else
            {
                Team currentTeam = new Team(teamName, creator);
                teams.Add(currentTeam);
                Console.WriteLine($"Team {currentTeam.Name} has been created by {currentTeam.Creator}!");
            }
        }

        private static bool IsTeamExist(List<Team> teams, string teamName)
        {
            return teams.Any(t => t.Name == teamName);
        }

        private static bool IsMemberExist(List<Team> teams, string memberName)
        {
            return teams.Any(t => t.Members.Contains(memberName));
        }

        private static bool IsCreatorExist(List<Team> teams, string creator)
        {
            return teams.Any(t => t.Creator == creator);
        }
    }

    public class Team
    {
        private string name;

        private string creatorName;

        private List<string> members;

        public Team(string teamName, string creatorName)
        {
            Name = teamName;
            Creator = creatorName;
            Members = new List<string>();
        }

        public string Name { get; set; }

        public string Creator { get; set; }

        public List<string> Members { get; set; }

        //public override string ToString()
        //{
        //    StringBuilder text = new StringBuilder();
        //    text.AppendLine(Name);
        //    text.AppendLine($"- {Creator}");

        //    foreach (var member in Members.OrderBy(m => m))
        //    {
        //        text.AppendLine($"-- {member}");
        //    }

        //    return text.ToString().Trim();
        //}

    }
}
