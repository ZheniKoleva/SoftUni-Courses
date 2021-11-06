namespace _07.MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Enumerators;
    using Interfaces;
    using Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<ISoldier> soldiers = new List<ISoldier>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] soldierData = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                ISoldier soldier = CreateSoldier(soldierData, soldiers);
                soldiers.Add(soldier);

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, soldiers));
        }

        private static ISoldier CreateSoldier(string[] soldierData, List<ISoldier> soldiers)
        {
            ISoldier soldier = null;

            string soldierType = soldierData[0];
            int id = int.Parse(soldierData[1]);
            string firstName = soldierData[2];
            string lastName = soldierData[3];

            switch (soldierType)
            {
                case "Private":
                    decimal salary = decimal.Parse(soldierData[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                    break;

                case "LieutenantGeneral":
                    salary = decimal.Parse(soldierData[4]);
                    string[] privatesData = soldierData[5..];
                    List<IPrivate> privates = TakePrivates(privatesData, soldiers);

                    soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                    break;

                case "Engineer":
                    salary = decimal.Parse(soldierData[4]);

                    if (Enum.TryParse(soldierData[5], out Corps corps))
                    {
                        string[] repairsData = soldierData[6..];
                        List<IRepair> repairs = TakeRepairs(repairsData);

                        return new Engineer(id, firstName, lastName, salary, corps, repairs);
                    }                    
                    
                    break;

                case "Commando":
                    salary = decimal.Parse(soldierData[4]);

                    if (Enum.TryParse(soldierData[5], out corps))
                    {
                        string[] missionsData = soldierData[6..];
                        List<IMission> missions = TakeMissions(missionsData);

                        soldier = new Commando(id, firstName, lastName, salary, corps, missions);
                    }

                    break;

                case "Spy":
                    int codeNumber = int.Parse(soldierData[4]);
                    soldier = new Spy(id, firstName, lastName, codeNumber);
                    break;               
            }

            return soldier;            
        }

        private static List<IMission> TakeMissions(string[] missionsData)
        {
            List<IMission> missions = new List<IMission>();

            for (int i = 0; i < missionsData.Length - 1; i += 2)
            {
                string codeName = missionsData[i];

                if (Enum.TryParse(missionsData[i + 1], out State missionState))
                {
                    missions.Add(new Mission(codeName, missionState));
                }
            }

            return missions;
        }

        private static List<IRepair> TakeRepairs(string[] repairsData)
        {
            List<IRepair> repairs = new List<IRepair>();

            for (int i = 0; i < repairsData.Length - 1; i += 2)
            {
                string partName = repairsData[i];
                int workHour = int.Parse(repairsData[i + 1]);

                repairs.Add(new Repair(partName, workHour));
            }

            return repairs;
        }

        private static List<IPrivate> TakePrivates(string[] privatesData, List<ISoldier> soldiers)
        {
            List<IPrivate> privates = new List<IPrivate>();

            foreach (var privateId in privatesData)
            {
                int currentId = int.Parse(privateId);
                privates.Add((IPrivate)soldiers.First(s => s.Id == currentId));
            }

            return privates;
        }
    }
}
