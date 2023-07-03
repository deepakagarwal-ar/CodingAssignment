using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanupApp
{
    internal class OracleConnection : IConnectionFactory
    {
        private readonly string oracleConnectionString;

        public OracleConnection(string connectionString) { 
            // this can be fetched from the configuration.
            this.oracleConnectionString = connectionString;
        }

        public string ConnectionString
        {
            get { return oracleConnectionString; }
        }
    }
}
