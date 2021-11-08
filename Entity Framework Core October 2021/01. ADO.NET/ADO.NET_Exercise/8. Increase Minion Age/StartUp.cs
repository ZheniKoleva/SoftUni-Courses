using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

using ADO.NET.Exercise;

namespace _8.IncreaseMinionAge
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            int[] IDs = ReadData();

            SqlConnection connection = new SqlConnection(Connection.CONNECTION_TO_Minions);
            await connection.OpenAsync();

            await using (connection)
            {
                await IncreaseMinionAgeAsync(connection, IDs);
            }
        }

        private static async Task IncreaseMinionAgeAsync(SqlConnection connection, int[] IDs)
        {
            SqlCommand increaseAge = new SqlCommand(Queries.INCREASE_MINION_AGE, connection);

            foreach(var minionId in IDs)
            {
                increaseAge.Parameters.AddWithValue("@minionId", minionId);
                await increaseAge.ExecuteNonQueryAsync();
                increaseAge.Parameters.Clear();
            }

            SqlCommand printCommand = new SqlCommand(Queries.GET_MINIONS_NAME_AGE, connection);
            SqlDataReader reader = await printCommand.ExecuteReaderAsync();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    string name = reader.GetString(0);
                    int age = reader.GetInt32(1);

                    Console.WriteLine($"{name} {age}");
                }
            }

        }

        private static int[] ReadData()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
