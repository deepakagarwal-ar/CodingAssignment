using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanupApp
{
    class Repository : IRepository
    {
        private readonly IConnectionFactory sqlconnection;

        public Repository(IConnectionFactory connection)
        {
            this.sqlconnection = connection;
        }

        public async Task Cleanup(string identifier)
        {
            var statements = new List<string>
            {
               "DELETE FROM SomeTable1 WHERE Identifier = '" + identifier + "'",
               "DELETE FROM SomeTable2 WHERE Identifier = '" + identifier + "'",
               "DELETE FROM SomeTable3 WHERE Identifier = '" + identifier + "'",
               "DELETE FROM SomeTable4 WHERE Identifier = '" + identifier + "'",
               "DELETE FROM SomeTable5 WHERE Identifier = '" + identifier + "'"
            };

            using (var sqlConnection = new SqlConnection(this.sqlconnection.ConnectionString))
            {
                sqlConnection.Open();

                // We can use the same command & connection to execute all the items in the list.
                using (var command = new SqlCommand())
                {
                    command.Connection = sqlConnection;

                    Parallel.ForEach(statements, async (statement) =>
                    {
                        command.CommandText = statement;

                        // To run the command in the databse execute non query should be executed
                        // This is one bug hope in the project.
                        await command.ExecuteNonQueryAsync();
                    });
                }

                // Closing the connection might not required as we are wrapping it in using
                // but for the safer side we can close it.
                sqlConnection.Close();
            }

            await Task.CompletedTask;
        }
    }
}
