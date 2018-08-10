using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using II.ContollerHelpers;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace II.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        public IEnvironmentConfiguration EnvironmentConfiguration { get; set; }
        private IMapper _mapper;
        protected Common.Configuration.EnvironmentConfiguration EnvironmentConfig;

        

        public BaseController(IEnvironmentConfiguration environmentConfiguration, IMapper mapper)
        {
        //    EnvironmentConfiguration = environmentConfiguration;
        //    _mapper = mapper;
        //    EnvironmentConfig = mapper.Map<EnvironmentConfiguration,Common.Configuration.EnvironmentConfiguration>((EnvironmentConfiguration)environmentConfiguration);
        }
       
    }
}
