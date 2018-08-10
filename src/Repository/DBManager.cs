using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Repository
{
    public class DBManager<TEntity> where TEntity : class
    {
        private MongoDbRepository<TEntity> _dbRepository;

        public DBManager(string _connectionString,string databaseName, string collection)
        {
 
            if (!string.IsNullOrEmpty(_connectionString) && !string.IsNullOrEmpty(databaseName) && !string.IsNullOrEmpty(collection))
            {
                _dbRepository = new MongoDbRepository<TEntity>(collection, _connectionString, databaseName);
            }
        }

        public IDBRepository<TEntity> Instance
        {
            get
            {
                return _dbRepository;
            }
        }
    }
}
