using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatewayAPI.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GatewayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IOptions<IdentityServerConfig> _identityServerConfig;

        public AuthController(IOptions<IdentityServerConfig> identityServerConfig)
        {
            _identityServerConfig = identityServerConfig;
        }

        [HttpPost("{token}")]
        public IActionResult Authenticate()
        {
            return StatusCode(200);
        }
    }
}