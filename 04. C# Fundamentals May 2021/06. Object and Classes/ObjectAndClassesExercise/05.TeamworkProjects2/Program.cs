using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TeamworkProjects
{
    class Team
    {
        public string Name { get; set; }

        public string Creator { get; set; }

        public List<string> Participants { get; set; }

        public Team(string creator, string teamName)
        {
            this.Name = teamName;
            this.Creator = creator;
            this.Participants = new List<string>();

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());

            List<Team> teamsList = new List<Team>(teamsCount);

            for (int i = 0; i < teamsCount; i++)
            {
                string[] parts = Console.ReadLine()
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);

                string creatorName = parts[0];
                string teamName = parts[1];

                if (IsTeamExists(teamsList, teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (IsCreatorHasOtherTeam(teamsList, creatorName))
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                    continue;
                }

                Team current = new Team(creatorName, teamName);
                current.Participants.Add(creatorName);
                teamsList.Add(current);

                Console.WriteLine($"Team {teamName} has been created by {creatorName}!");

            }

            string line = Console.ReadLine();

            while (line != "end of assignment")
            {
                string[] memberToJoin = line
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);

                string memberName = memberToJoin[0];
                string teamToJoin = memberToJoin[1];

                if (!IsTeamExists(teamsList, teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                    line = Console.ReadLine();
                    continue;
                }

                if (IsMemberATeam(teamsList, memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamToJoin}!");
                    line = Console.ReadLine();
                    continue;
                }

                foreach (Team item in teamsList)
                {
                    if (item.Name == teamToJoin)
                    {
                        item.Participants.Add(memberName);
                        break;
                    }
                }

                line = Console.ReadLine();
            }

            List<Team> sortedActive = teamsList
                .Where(a => a.Participants.Count > 1)
                .OrderByDescending(a => a.Participants.Count)
                .ThenBy(a => a.Name)
                .ToList();

            List<Team> teamsToDisband = teamsList
                .Where(a => a.Participants.Count == 1)
                .OrderBy(a => a.Name)
                .ToList();

            foreach (var item in sortedActive)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine($"- {item.Creator}");

                List<string> ordered = new List<string>();

                for (int i = 1; i < item.Participants.Count; i++)
                {
                    ordered.Add(item.Participants[i]);
                }

                ordered = ordered.OrderBy(m => m).ToList();

                foreach (var member in ordered)
                {
                    Console.WriteLine($"-- {member}");
                }
                    
            }

            Console.WriteLine("Teams to disband:");

            foreach (Team item in teamsToDisband)
            {
                Console.WriteLine(item.Name);
            }

        }

        private static bool IsMemberATeam(List<Team> teamsList, string memberName)
        {
            foreach (Team item in teamsList)
            {
                if (item.Participants.Contains(memberName))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsCreatorHasOtherTeam(List<Team> teamsList, string creatorName)
        {
            foreach (Team item in teamsList)
            {
                if (creatorName == item.Creator)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsTeamExists(List<Team> teamsList, string teamName)
        {
            foreach (Team item in teamsList)
            {
                if (teamName == item.Name)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

