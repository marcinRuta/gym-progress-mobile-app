using ClientApi.Application.Commands;
using ClientApi.Application.Dtos;
using ClientApi.Application.Queries;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientApiController : ControllerBase
    {
        private readonly IClientApiQueriesHandler clientApiQueriesHandler;

        

        private readonly ILogger<ClientApiController> _logger;

        public ClientApiController(ILogger<ClientApiController> logger, IClientApiQueriesHandler clientApiQueriesHandler)
        {
            _logger = logger;
            this.clientApiQueriesHandler = clientApiQueriesHandler;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string> { "test", "test" };
        }

        [HttpPost("registerUser")]
        public Response RegisterUser([FromBody] AddUserCredentialCommand credential)
        {

            return this.clientApiQueriesHandler.RegisterUser(credential);
        }
        [HttpPost("loginUser")]
        public Response LoginUser([FromHeader] string username, [FromHeader] string password)
        {
            var credential = new AddUserCredentialCommand(username, password);
            return this.clientApiQueriesHandler.LoginUser(credential);
        }

        [HttpPost("addUserDetails")]
        public Response AddUserDetails([FromHeader] string username, [FromHeader] string password, [FromBody] AddUserDetailsCommand details)
        {
            var credentials = new UserCredential(username, password);
            return this.clientApiQueriesHandler.AddUserDetails(details, credentials);
        }
        [HttpGet("UserDetails")]
        public UserDetails GetUserDetails([FromHeader] string username, [FromHeader] string password)
        {
            
            return this.clientApiQueriesHandler.GetUserDetails(username,password);
        }
    }
}
