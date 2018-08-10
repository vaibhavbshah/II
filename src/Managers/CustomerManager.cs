using Entities;
using MongoDB.Bson;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Helper;
using Common.Configuration;
using MongoDB.Bson.Serialization;
using Microsoft.Extensions.Options;
using AutoMapper;

namespace Managers
{
    public class CustomerManager
    {
        private IMapper _mapper;
        private readonly IDBRepository<BsonDocument> dbCustomer = null;
        private readonly IDBRepository<BsonDocument> dbUser = null;
        public CustomerManager(IOptions<EnvironmentConfiguration> environmentConfigurationOptions, IMapper mapper)
        {
            _mapper = mapper;
            dbCustomer = new DBManager<BsonDocument>
                (environmentConfigurationOptions.Value.ConnectionString,
                environmentConfigurationOptions.Value.DatabaseName,
                 "customer").Instance;

            dbUser = new DBManager<BsonDocument>
            (environmentConfigurationOptions.Value.ConnectionString,
            environmentConfigurationOptions.Value.DatabaseName,
             "user").Instance;
        }

        public bool AddCustomer(Customer customer)
        {
            try
            {
                User user = _mapper.Map<User>(customer);
                user._id = Guid.NewGuid();

                dbUser.Insert(BsonSerializer.Deserialize<BsonDocument>
                        (
                            MongoHelper.ReadRequestAsString(user)
                           ));

                
                dbCustomer.Insert(
                    BsonSerializer.Deserialize<BsonDocument>
                        (
                            MongoHelper.ReadRequestAsString(customer)
                           ));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}