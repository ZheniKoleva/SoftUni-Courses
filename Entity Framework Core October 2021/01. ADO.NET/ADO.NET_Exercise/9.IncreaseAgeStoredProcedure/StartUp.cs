using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

using ADO.NET.Exercise;

namespace _9.IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(Connection.CONNECTION_TO_Minions);
            await connection.OpenAsync();

            int id = int.Parse(Console.ReadLine());

            await using (connection)
            {
                await IncreaseAgeByStoreProsedureAsync(connection, id);
            }
        }

        private static async Task IncreaseAgeByStoreProsedureAsync(SqlConnection connection, int id)
        {
            SqlCommand executeStoreProcedure = new SqlCommand(Queries.INCREASE_AGE_STORED_PROCEDURE, connection);
            executeStoreProcedure.Parameters.AddWithValue("@id", id);
            await executeStoreProcedure.ExecuteNonQueryAsync();

            SqlCommand printMinion = new SqlCommand(Queries.GET_MINION_NAME_AGE_BY_ID, connection);
            printMinion.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = printMinion.ExecuteReader();

            await using (reader)
            {
                while (await reader.ReadAsync())
                {
                    string name = (string)reader["Name"];
                    int age = (int)reader["Age"];
                    Console.WriteLine($"{name} - {age} years old");
                }
            }


        }
    }
}
