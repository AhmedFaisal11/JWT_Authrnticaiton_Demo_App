using Auth.Demo.models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Demo.AuthenticationManager;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Auth.Demo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : ControllerBase 
    {
        private readonly IJwtAuthenticaitonManager jwtAuthenticaitonManager;

        public NameController(IJwtAuthenticaitonManager jwtAuthenticaitonManager)
        {
            this.jwtAuthenticaitonManager = jwtAuthenticaitonManager;
        }
        // GET: api/<NameController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "New York", "New Jersey" };
        }

        // GET api/<NameController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCrud userCrud)
        {
            var token = jwtAuthenticaitonManager.Authentication(userCrud.Username, userCrud.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
        
    }
}
