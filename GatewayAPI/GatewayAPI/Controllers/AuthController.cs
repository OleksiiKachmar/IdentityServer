using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        public async Task<IActionResult> Authenticate(string userCredentials)
        {
            HttpClient client = new HttpClient();
            var result = await client.PostAsync(_identityServerConfig.Value.Url, new StringContent(userCredentials, Encoding.UTF8, "application/json"));

            return new JsonResult(result.Content);
        }

        [HttpGet("json")]
        public async Task<IActionResult> GetJson()
        {
            return new JsonResult(new { SomeProperty = "Some value" });
        }

        [HttpGet]
        public async Task<IActionResult> GetJsonGet()
        {
            return new JsonResult(new { SomeProperty = "Some value get" });
        }
    }
}