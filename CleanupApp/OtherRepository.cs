using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanupApp
{
    /// <summary>
    /// Other repositories to to clean up the data.
    /// </summary>
    internal class OtherRepository : IRepository
    {
        private readonly IConnectionFactory otherConnection;

        public OtherRepository(IConnectionFactory connection)
        {
            this.otherConnection = connection;
        }

        public Task Cleanup(string identifier)
        {

            //Connect to oracle using the connection factory.

            // Cleaup up work.

            // Need to implement this method to clear the data
            // from other database using connection string.
            return Task.CompletedTask;
        }
    }
}
