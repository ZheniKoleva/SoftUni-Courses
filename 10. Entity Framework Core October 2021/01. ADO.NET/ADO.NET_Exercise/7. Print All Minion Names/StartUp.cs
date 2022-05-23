using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

using ADO.NET.Exercise;

namespace _7.PrintAllMinionNames
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(Connection.CONNECTION_TO_Minions);
            await connection.OpenAsync();

            await using (connection)
            {
                await PrintMinionsAsync(connection);
            }
        }

        private static async Task PrintMinionsAsync(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(Queries.PRINT_ALL_MINION_NAMES, connection);

            SqlDataReader reader = await command.ExecuteReaderAsync();

            List<string> minions = new List<string>();

            await using (reader)
            {
                while (await reader.ReadAsync())
                {
                    minions.Add((string)reader["Name"]);
                }
            }

            int endIndx = minions.Count / 2;

            for (int i = 0; i < endIndx; i++)
            {
                Console.WriteLine(minions[i]);
                Console.WriteLine(minions[minions.Count - 1 - i]);
            }

            if (endIndx % 2 != 0)
            {
                Console.WriteLine(minions[endIndx]);
            }
        }
    }
}
