using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

using ADO.NET.Exercise;

namespace _4.AddMinion
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {            
            string[] minionData = Console.ReadLine()?
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string minionName = minionData[1];
            int minionAge = int.Parse(minionData[2]);
            string minionTown = minionData[3];

            
            string villainName = Console.ReadLine()?
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];

            SqlConnection connection = new SqlConnection(Connection.CONNECTION_TO_Minions);
            await connection.OpenAsync();

            await using (connection)
            {
                await AddMinionAsync(connection, minionName, minionAge, minionTown, villainName);
            }
        }

        private static async Task AddMinionAsync(SqlConnection connection, 
            string minionName, int minionAge, string minionTown, string villainName)
        {
            int rowAffected;
            SqlCommand checkTown = new SqlCommand(Queries.GET_TOWN_ID_BY_NAME, connection);
            checkTown.Parameters.AddWithValue("@townName", minionTown);

            var townResult = await checkTown.ExecuteScalarAsync();            

            if (townResult == null)
            {
                SqlCommand addTown = new SqlCommand(Queries.INSERT_TOWN, connection);
                addTown.Parameters.AddWithValue("@townName", minionTown);

                rowAffected = await addTown.ExecuteNonQueryAsync();

                if (rowAffected == 0)
                {
                    Console.WriteLine("A problem has occured. Town not added!");
                    return;
                }

                Console.WriteLine($"Town {minionTown} was added to the database.");               
            }

            int townId = (int)await checkTown.ExecuteScalarAsync();

            SqlCommand checkVillain = new SqlCommand(Queries.GET_VILLAIN_ID_BY_NAME, connection);
            checkVillain.Parameters.AddWithValue("@Name", villainName);

            var villainResult = await checkVillain.ExecuteScalarAsync();

            if (villainResult == null)
            {
                SqlCommand addVillain = new SqlCommand(Queries.INSERT_VILLAINS_BY_NAME_EVIL, connection);
                addVillain.Parameters.AddWithValue("@villainName", villainName);

                rowAffected = await addVillain.ExecuteNonQueryAsync();

                if (rowAffected == 0)
                {
                    Console.WriteLine("A problem has occured. Villain not added!");
                    return;
                }

                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            int villainId = (int)await checkVillain.ExecuteScalarAsync();

            SqlCommand checkMinion = new SqlCommand(Queries.GET_MINION_ID_BY_NAME, connection);
            checkMinion.Parameters.AddWithValue("@Name", minionName);

            var minionResult = await checkMinion.ExecuteScalarAsync();

            if (minionResult == null)
            {
                SqlCommand addMinion = new SqlCommand(Queries.INSERT_MINION_BY_AGE_NAME_TOWNID, connection);               
                addMinion.Parameters.AddWithValue("@name", minionName);
                addMinion.Parameters.AddWithValue("@age", minionAge);
                addMinion.Parameters.AddWithValue("@townId", townId);

                rowAffected = await addMinion.ExecuteNonQueryAsync();

                if (rowAffected == 0)
                {
                    Console.WriteLine("A problem has occured. Minion not added!");
                }


                Console.WriteLine($"Minion {minionName} was added to the database.");
            }

            int minionId = (int)await checkMinion.ExecuteScalarAsync();

            SqlCommand mapMinionToVillain = new SqlCommand(Queries.MAP_MINNION_VILLAIN_BY_IDs, connection);
            mapMinionToVillain.Parameters.AddWithValue("@minionId", minionId);
            mapMinionToVillain.Parameters.AddWithValue("@villainId", villainId);

            rowAffected = await mapMinionToVillain.ExecuteNonQueryAsync();

            if (rowAffected == 0)
            {
                Console.WriteLine("A problem has occured. Minion not added to villain!");                
            }
            else
            {
                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
            
        }
    }
}
