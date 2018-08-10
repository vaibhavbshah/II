using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Common.Helper
{
    public static class MongoHelper
    {

        public static string ReadRequestAsString(object entity)
        {
            return JsonConvert.SerializeObject(entity);
        }
    }
}
