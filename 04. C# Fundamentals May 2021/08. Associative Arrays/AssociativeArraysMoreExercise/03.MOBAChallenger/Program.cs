using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MOBAChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Skill>> playerPool = new Dictionary<string, List<Skill>>();

            string input = Console.ReadLine();

            while (input != "Season end")
            {
                if (input.Contains(" -> "))
                {
                    string[] parts = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                    string name = parts[0];
                    string position = parts[1];
                    int skill = int.Parse(parts[2]);

                    FillPlayerPoll(playerPool, name, position, skill);

                }
                else
                {
                    string[] parts = input.Split(" vs ", StringSplitOptions.RemoveEmptyEntries);

                    string firstPlayer = parts[0];
                    string secondPlayer = parts[1];

                    if (!IsPlayerExists(playerPool, firstPlayer)
                        || !IsPlayerExists(playerPool, secondPlayer))
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    List<string> commonElements = HasCommonSkill(playerPool[firstPlayer], playerPool[secondPlayer]);

                    if (commonElements.Count > 0)
                    {
                        DuelPlayers(playerPool, commonElements, firstPlayer, secondPlayer);
                    }

                }

                input = Console.ReadLine();
            }

            playerPool = playerPool
                .OrderByDescending(a => a.Value.Sum(y => y.SkillPoints))
                .ThenBy(a => a.Key)
                .ToDictionary(a => a.Key, a => a.Value);

            PrintPlayers(playerPool);

        }

        private static List<string> HasCommonSkill(List<Skill> first, List<Skill> second)
        {
            return first.Select(x => x.Position).Intersect(second.Select(x => x.Position)).ToList();
        }

        private static void DuelPlayers(Dictionary<string, List<Skill>> playerPool, List<string> commonElements, string firstPlayer, string secondPlayer)
        {
            foreach (var element in commonElements)
            {
                Skill firstSkill = playerPool[firstPlayer].First(x => x.Position == element);
                Skill secondSkill = playerPool[secondPlayer].First(x => x.Position == element);

                if (firstSkill.SkillPoints > secondSkill.SkillPoints)
                {
                    playerPool.Remove(secondPlayer);
                    return;
                }
                else if (firstSkill.SkillPoints < secondSkill.SkillPoints)
                {
                    playerPool.Remove(firstPlayer);
                    return;
                }
            }

            //foreach (var firstSkill in playerPool[firstPlayer]) // позицията всъщност е вътрешният речник
            //{
            //    foreach (var secondSkill in playerPool[secondPlayer])
            //    {
            //        if (firstSkill.Position == secondSkill.Position)
            //        {
            //            if (firstSkill.SkillPoints > secondSkill.SkillPoints)
            //            {
            //                playerPool.Remove(secondPlayer);
            //                return;
            //            }
            //            else if (firstSkill.SkillPoints < secondSkill.SkillPoints)
            //            {
            //                playerPool.Remove(secondPlayer);
            //                return;
            //            }
            //        }

            //    }

            //}
        }

        private static bool IsPlayerExists(Dictionary<string, List<Skill>> playerPool, string player)
        {
            return playerPool.ContainsKey(player);
        }

        private static void PrintPlayers(Dictionary<string, List<Skill>> playerPool)
        {
            foreach (var player in playerPool)
            {
                Console.WriteLine($"{player.Key}: {player.Value.Sum(y => y.SkillPoints)} skill");

                List<Skill> current = player.Value
                    .OrderByDescending(a => a.SkillPoints)
                    .ThenBy(a => a.Position)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, current));
            }
        }

        private static void FillPlayerPoll(Dictionary<string, List<Skill>> playerPool, string name, string position, int skill)
        {
            if (!playerPool.ContainsKey(name))
            {
                playerPool.Add(name, new List<Skill> { new Skill(position, skill) });
            }

            if (!playerPool[name].Any(x => x.Position == position)) // нямаме такъв skill
            {
                playerPool[name].Add(new Skill(position, skill));
            }

            if (playerPool[name].Any(x => x.Position == position && x.SkillPoints < skill))
            {
                Skill currentSkill = playerPool[name].First(x => x.Position == position);
                currentSkill.SkillPoints = skill;
            }
        }
    }

    //public class Skill
    //{
    //    public Skill(string position, int skillPoints)
    //    {
    //        this.Position = position;
    //        this.SkillPoints = skillPoints;
    //    }

    //    public string Position { get; set; }

    //    public int SkillPoints { get; set; }

    //    public override string ToString()
    //    {
    //        return $"- {Position} <::> {SkillPoints}";
    //    }

    //}
}
