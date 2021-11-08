using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

using ADO.NET.Exercise;

namespace _6.RemoveVillain
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection(Connection.CONNECTION_TO_Minions);
            await connection.OpenAsync();

            await using (connection)
            {
                await RemoveVillainAsync(connection, villainId);
            }
        }

        private static async Task RemoveVillainAsync(SqlConnection connection, int villainId)
        {
            SqlCommand checkName = new SqlCommand(Queries.GET_VILLAIN_NAME_BY_ID, connection);
            checkName.Parameters.AddWithValue("@Id", villainId);

            var result = await checkName.ExecuteScalarAsync();

            if (result == null)
            {
                Console.WriteLine("No such villain was found.");
                return;
            }

            string villainName = (string)result;

            SqlCommand removeFromMapping = new SqlCommand(Queries.REMOVE_VILLAIN_BY_ID_FROM_MAPPING, connection);
            removeFromMapping.Parameters.AddWithValue("@villainId", villainId);

            int removedMinions = await removeFromMapping.ExecuteNonQueryAsync();

            SqlCommand removeVillain = new SqlCommand(Queries.REMOVE_VILLAIN_BY_ID, connection);
            removeVillain.Parameters.AddWithValue("@villainId", villainId);

            await removeVillain.ExecuteNonQueryAsync();

            Console.WriteLine($"{villainName} was deleted.");
            Console.WriteLine($"{removedMinions} minions were released.");
        }
    }
}
