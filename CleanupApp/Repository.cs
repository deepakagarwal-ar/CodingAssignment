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
        private readonly string _sqlConnectionString;

        public Repository(string sqlConnectionString)
        {
            _sqlConnectionString = sqlConnectionString;
        }

        public Task Cleanup(string identifier)
        {
            var statements = new List<string>
            {
               "DELETE FROM SomeTable1 WHERE Identifier = '" + identifier + "'",
               "DELETE FROM SomeTable2 WHERE Identifier = '" + identifier + "'",
               "DELETE FROM SomeTable3 WHERE Identifier = '" + identifier + "'",
               "DELETE FROM SomeTable4 WHERE Identifier = '" + identifier + "'",
               "DELETE FROM SomeTable5 WHERE Identifier = '" + identifier + "'"
            };

            using (var sqlConnection = new SqlConnection(_sqlConnectionString))
            {
                sqlConnection.Open();

                Parallel.ForEach(statements, async (statement) =>
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = sqlConnection;
                        command.CommandText = statement;

                        // To run the command in the databse execute non query should be executed
                        // This is bug i hope in the project.
                        await command.ExecuteNonQueryAsync();
                    }
                });
            }

            return Task.CompletedTask;
        }
    }
}
