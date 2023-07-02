using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanupApp
{
    /// <summary>
    /// Interface for different repositories
    /// </summary>
    public interface IRepository
    {
        Task Cleanup(string identifier);
    }
}
