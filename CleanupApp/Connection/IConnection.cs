using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanupApp
{
    internal interface IConnectionFactory
    {
        string ConnectionString { get; }

    }
}
