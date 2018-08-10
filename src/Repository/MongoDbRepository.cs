using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;


namespace Repository
{
    public class MongoDbRepository<TEntity> : IDBRepository<TEntity> where TEntity : class
    {
        private IMongoDatabase database;
        private IMongoCollection<TEntity> collection;
        private string _collection;
        private string _connectionString;
        private string _databasename;

        public  MongoDbRepository(string collection, string connectionString, string databasename)
        {
            _collection = collection;
            _connectionString = connectionString;
            _databasename = databasename;
            GetDatabase();
            GetCollection();
        }


        public bool Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(string id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(TEntity entity)
        {
            try
            {
                collection.InsertOne(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IList<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return collection
                    .AsQueryable<TEntity>()
                        .Where(predicate.Compile())
                            .ToList();
        }

        public IList<TEntity> SearchFor(string key, string value)
        {
            throw new NotImplementedException();
        }

        public bool Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        private void GetDatabase()
        {
            var client = new MongoClient(_connectionString);
            database = client.GetDatabase(_databasename);
        }

        private void GetCollection()
        {
            collection = database.GetCollection<TEntity>(_collection);
        }
    }
}
