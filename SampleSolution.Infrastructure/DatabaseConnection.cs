using System.Data;
using System.Data.Common;

namespace SampleSolution.Infrastructure
{
    /// <summary>
    ///     Used for accessing Pervasive database and sending commands/queries.
    /// </summary>
    public static class DatabaseConnection
    {
        private const string ConnectionString = "Server Name=serverName;Database Name=databaseName;User ID=userId;Password=password;";

        /// <summary>
        ///     Executes provided SQL query using connection obtained from <seealso cref="GetDatabaseConnection"/>.
        /// </summary>
        /// <param name="query">SQL syntax query.</param>
        /// <returns>Resultant <seealso cref="DataTable"/></returns>
        public static DataTable GetDataTableFromQuery(string query)
        {
            var queryDataTable = new DataTable();

            using var sqlConnection = GetDatabaseConnection();

            using var command = sqlConnection.CreateCommand();
            command.CommandText = query;

            using var reader = command.ExecuteReader();
            queryDataTable.Load(reader);

            return queryDataTable;
        }

        /// <summary>
        ///      Executes provided SQL query using connection obtained from <seealso cref="GetDatabaseConnection"/>.
        /// </summary>
        /// <param name="query">SQL syntax query.</param>
        /// <returns>Bool <seealso cref="DataTable"/></returns>
        public static int UpdateDataTableFromQuery(string query)
        {
            var queryDataTable = new DataTable();
            using var sqlConnection = GetDatabaseConnection();
            using var command = sqlConnection.CreateCommand();
            command.CommandText = query;
            return command.ExecuteNonQuery();
        }

        /// <summary>
        ///     Creates and opens a connection using hard-coded connection string.
        /// </summary>
        /// <returns>Open <seealso cref="DbConnection"/></returns>
        private static DbConnection GetDatabaseConnection()
        {
            var databaseConnection = DbProviderFactories.GetFactory("Pervasive.Data.SqlClient").CreateConnection();
            databaseConnection!.ConnectionString = ConnectionString;
            databaseConnection.Open();
            return databaseConnection;
        }
    }
}