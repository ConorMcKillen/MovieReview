using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

using MMS.Data.Services;
using MMS.Data.Models;
using MMS.Rest.Models;
using MMS.Rest.Helpers;

namespace MMS.Rest.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IPatientService svc;
        private readonly string secret;

        public UserController(IPatientService service, IConfiguration config)
        {
            svc = service;
            secret = config.GetValue<string>("JwtConfig:Secret");
        }

        // POST api/user/login

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<User> Login(UserLoginModel login)
        {
            var user = svc.Authenticate(login.Email, login.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Email or Password is incorrect" });
            }
            return AuthBuilder.SignJwtToken(user, secret);
        }

    }
}
