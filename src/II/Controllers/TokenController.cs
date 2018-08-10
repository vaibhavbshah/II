using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace II.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private IConfiguration _config;
        private AuthenticationManager _authenticationManager;

        public TokenController(IConfiguration config, AuthenticationManager authenticationManager)
        {
            _config = config;
            _authenticationManager = authenticationManager;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("CreateToken")]
        public IActionResult CreateToken([FromBody]Login login)
        {
            IActionResult response = Unauthorized();
            var authenticated = Authenticate(login);
            User user;
            if (authenticated != false)
            {
                user = _authenticationManager.AuthenticatedUser;
                var tokenString = BuildToken(login);
                user.AuthenticationToken = tokenString;
                response = Ok(user);
            }

            return response;
        }

        private bool Authenticate(Login login)
        {
            return _authenticationManager.AuthenticateUser(login);
        }

        private string BuildToken(Login login)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("FirstName",_authenticationManager.AuthenticatedUser.FirstName??""),
                new Claim("LastName",_authenticationManager.AuthenticatedUser.LastName??""),
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

  
    }
}
