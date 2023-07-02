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
        private readonly string _otherConnectionString;

        public OtherRepository(string otherConnectionString)
        {
            this._otherConnectionString = otherConnectionString;
        }

        public Task Cleanup(string identifier)
        {

            // Need to implement this method to clear the data
            // from other database using connection string.
            return Task.CompletedTask;
        }
    }
}
