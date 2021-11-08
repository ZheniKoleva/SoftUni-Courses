using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

using ADO.NET.Exercise;

namespace _5.ChangeTownNamesCasing
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            string country = Console.ReadLine();

            SqlConnection connection = new SqlConnection(Connection.CONNECTION_TO_Minions);
            await connection.OpenAsync();

            await using (connection)
            {
                await ChangeTownsCasingAsync(connection, country);
            }

        }

        private static async Task ChangeTownsCasingAsync(SqlConnection connection, string country)
        {
            SqlCommand changeCasing = new SqlCommand(Queries.CHANGE_TOWN_NAME_CASING, connection);
            changeCasing.Parameters.AddWithValue("@countryName", country);

            int affectedRows = await changeCasing.ExecuteNonQueryAsync();

            if (affectedRows == 0)
            {
                Console.WriteLine("No town names were affected.");
                return;
            }

            Console.WriteLine($"{affectedRows} town names were affected.");
            

            SqlCommand printChangedTowns = new SqlCommand(Queries.GET_TOWNS_BY_COUNTRYNAME, connection);
            printChangedTowns.Parameters.AddWithValue("@countryName", country);

            List<string> towns = new List<string>();
            SqlDataReader reader = printChangedTowns.ExecuteReader();
            
            await using (reader)
            {
                while (await reader.ReadAsync())
                {
                    towns.Add((string)reader["Name"]);
                }
            }

            Console.WriteLine($"[{string.Join(", ", towns)}]");
        }
    }
}
