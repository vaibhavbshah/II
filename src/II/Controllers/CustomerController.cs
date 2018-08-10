using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Managers;
using II.ContollerHelpers;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace II.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CustomerController : BaseController
   // public class CustomerController : Controller

    {
        private IEnvironmentConfiguration _environmentConfiguration;
        private CustomerManager _customerManager;

        public CustomerController(IEnvironmentConfiguration environmentConfiguration,IMapper mapper,CustomerManager customerManager) : base(environmentConfiguration, mapper)
        {
            _customerManager = customerManager;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Customer value)
        {
            var user = HttpContext.User;
            _customerManager.AddCustomer(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
