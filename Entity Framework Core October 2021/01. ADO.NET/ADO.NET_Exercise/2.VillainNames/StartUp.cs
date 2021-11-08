using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

using ADO.NET.Exercise;

namespace _2.VillainNames
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(Connection.CONNECTION_TO_Minions);
            await connection.OpenAsync();

            await using (connection)
            {
                await PrintVillainsNames(connection);
            }
        }

        private static async Task PrintVillainsNames(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(Queries.GET_VILLAINS_NAMES, connection);
            SqlDataReader reader = await command.ExecuteReaderAsync();

            await using (reader)
            {
                while (await reader.ReadAsync())
                {
                    string name = reader.GetString(0);
                    int minionsCount = reader.GetInt32(1);

                    Console.WriteLine($"{name} - {minionsCount}");
                    //Console.WriteLine($"{(string)reader["Name"]} - {(int)reader["MinionsCount"]}");
                }
            }
        }
    }
}
