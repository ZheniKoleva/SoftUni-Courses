using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ADO.NET.Exercise
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(Connection.CONNECTION_TO_Master);
            
            await connection.OpenAsync();

            await using (connection)
            {
                SqlCommand createMinionsDB = new SqlCommand(Queries.CREATE_MINIONSDB, connection);

                await createMinionsDB.ExecuteNonQueryAsync();

                Console.WriteLine("MinionsDB was created successfully");
            }

            SqlConnection connectionToMinions = new SqlConnection(Connection.CONNECTION_TO_Minions);

            await connectionToMinions.OpenAsync();

            await using (connectionToMinions)
            {
                SqlCommand createTables = new SqlCommand(Queries.CREATE_MINIONS_TABLES, connectionToMinions);

                await createTables.ExecuteNonQueryAsync();

                Console.WriteLine("Tables were created successfully");

                SqlCommand insertDataIntoTables = new SqlCommand(Queries.INSERT_DATA_INTO_TABLES, connectionToMinions);

                await insertDataIntoTables.ExecuteNonQueryAsync();

                Console.WriteLine("Data was imported successfully");
            }
        }

    }
    
}
