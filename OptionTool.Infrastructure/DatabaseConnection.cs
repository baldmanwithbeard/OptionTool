using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OptionTool.Infrastructure.Repositories;

namespace OptionTool.Infrastructure
{
    /// <summary>
    ///     Used for accessing Pervasive database and sending commands/queries.
    /// </summary>
    public static class DatabaseConnection
    {
        private static IConfiguration Config => new ConfigurationBuilder().AddUserSecrets<BaseEntityRepository>().Build();

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
            //var databaseConnection = DbProviderFactories.GetFactory("Pervasive.Data.SqlClient").CreateConnection();
            var connectionString = Config["AppSettings:ConnectionString"];
            var databaseConnection = new SqlConnection(connectionString);
            databaseConnection.Open();
            return databaseConnection;
        }

        public static SqlCommandBuilder GetCommandBuilder(string tableName)
        {
            var connection = new SqlConnection(Config["AppSettings:ConnectionString"]);
            connection.Open();
            return new SqlCommandBuilder(new SqlDataAdapter($"SELECT * FROM {tableName}", connection));
        }
    }
}