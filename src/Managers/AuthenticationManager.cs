using Common.Configuration;
using Entities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public class AuthenticationManager
    {
        private readonly IDBRepository<User> dbUser = null;
        public User AuthenticatedUser { get; set; }

        public AuthenticationManager(IOptions<EnvironmentConfiguration> environmentConfigurationOptions)
        {
            dbUser = new DBManager<User>
                (environmentConfigurationOptions.Value.ConnectionString,
                environmentConfigurationOptions.Value.DatabaseName,
                 "user").Instance;
        }

        public bool AuthenticateUser(Login login)
        {
            IList<User> User = dbUser.SearchFor(c => (c.UserName == login.UserName) && (c.Password == login.Password));
            AuthenticatedUser = User[0]??null;
            return User == null ? false : User.Count > 0 ? true : false;
        }
    }
}
