using System;

namespace Entities
{
    public class User
    {
        public Guid _id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AuthenticationToken { get; set; }
    }
}