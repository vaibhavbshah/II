using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace II.ContollerHelpers
{
    public interface IDBConfiguration
    {
        string ConnectionString { get; }
        string DatabaseName { get; }
    }
    public interface IEnvironmentConfiguration
    {

    }

    public class EnvironmentConfiguration : IDBConfiguration, IEnvironmentConfiguration
    {
        private IConfiguration _configuration;

        //public EnvironmentConfiguration(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        public EnvironmentConfiguration()
        {

        }


        public string ConnectionString { get; set; }
            
        public string DatabaseName { get; set; }
    }
}
