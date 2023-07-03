using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanupApp
{
    internal class SqlDBConnection : IConnectionFactory
    {
        private readonly string sqlConnectionString;

        public SqlDBConnection(string connectionString) { 
            // this can be fetched from the configuration.
            this.sqlConnectionString = connectionString;
        }

        public string ConnectionString
        {
            get { return sqlConnectionString; }
        }
    }
}
