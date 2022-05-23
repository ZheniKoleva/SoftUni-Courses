using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            string line = Console.ReadLine();
           
            while (line != "End")
            {
                string[] data = line.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string companyName = data[0];
                string id = data[1];

                FillDictionary(companies, companyName, id);

                line = Console.ReadLine();
            }

            PrintCompanies(companies);
        }

        private static void PrintCompanies(Dictionary<string, List<string>> companies)
        {
            foreach (var company in companies.OrderBy(x => x.Key))
            {
                Console.WriteLine(company.Key);
                Console.Write("-- ");
                Console.WriteLine(string.Join($"\n-- ", company.Value));
            }
        }

        private static void FillDictionary(Dictionary<string, List<string>> companies, string companyName, string id)
        {
            if (!companies.ContainsKey(companyName))
            {
                companies.Add(companyName, new List<string>());
            }

            if (!companies[companyName].Contains(id))
            {
                companies[companyName].Add(id);
            }            
        }
    }
}
