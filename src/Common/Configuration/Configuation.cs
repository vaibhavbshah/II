using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Configuration
{
    public interface IDBConfiguration
    {
        string ConnectionString
        {
            get; set;
        }
        string DatabaseName
        {
            get; set;
        }

    }

    public class EnvironmentConfiguration : IDBConfiguration
    {

        public string ConnectionString
        {
            get; set;
        }
        public string DatabaseName
        {
            get; set;
        }
    }
}

