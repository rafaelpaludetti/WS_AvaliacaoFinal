using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS_AvaliacaoFinal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS_AvaliacaoFinal.Models;
using Microsoft.Extensions.Configuration;

namespace WS_AvaliacaoFinal.Controllers
{
    [ApiController]
    [Route("auth")]
    public class UserWSController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public UserWSController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<dynamic> GetUser(UserVO payload)
        {

            UserDAL dal = new UserDAL();

            var userF = dal.GetUser(payload.Username, payload.Password);

            if (userF.Username == null)
                return NotFound(new { message = "Usuário e/ou senha incorretos" });

            TokenServices services = new TokenServices(_configuration);
            var token = services.GenerateToken(userF);

            userF.Password = "";

            return new
            {
                user = userF,
                token = token
            };
        }
    }
}
