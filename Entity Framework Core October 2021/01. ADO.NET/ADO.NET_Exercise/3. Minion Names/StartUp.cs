using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

using ADO.NET.Exercise;

namespace _3.MinionNames
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(Connection.CONNECTION_TO_Minions);
            await connection.OpenAsync();

            int villainId = int.Parse(Console.ReadLine());

            await using (connection)
            {
                await PrintMinionNamesByVillainId(connection, villainId);
            }
        }

        private static async Task PrintMinionNamesByVillainId(SqlConnection connection, int villainId)
        {
            SqlCommand command = new SqlCommand(Queries.GET_VILLAIN_NAME_BY_ID, connection);
            command.Parameters.AddWithValue("@Id", villainId);

            string villainName = (string)await command.ExecuteScalarAsync();

            if (villainName == null)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                return;
            }

            Console.WriteLine($"Villain: {villainName}");

            SqlCommand minionsCommand = new SqlCommand(Queries.GET_MINIONS_NAMES_BY_VILLAIN_ID, connection);
            minionsCommand.Parameters.AddWithValue("@Id", villainId);

            await using (minionsCommand)
            {
                SqlDataReader reader = await minionsCommand.ExecuteReaderAsync();

                if (!reader.HasRows)
                {
                    Console.WriteLine("(no minions)");
                    return;
                }

                while (await reader.ReadAsync())
                {
                    Console.WriteLine($"{(long)reader["RowNum"]}. {(string)reader["Name"]} {(int)reader["Age"]}");
                }
            }

        }
    }
}
