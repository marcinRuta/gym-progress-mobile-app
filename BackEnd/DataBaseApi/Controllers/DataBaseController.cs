using DataBaseApi.Application.Commands;
using DataBaseApi.Application.Dtos;
using DataBaseApi.Application.Queries;
using DataBaseApi.Commands;
using DataBaseApi.Domain.Daos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataBaseController : ControllerBase
    {

        private readonly IDataBaseQueriesHandler dataBaseQueriesHandler;
        private readonly ICommandHandler dataBaseCommandHandler;

        private readonly ILogger<DataBaseController> _logger;

        public DataBaseController(ILogger<DataBaseController> logger, IDataBaseQueriesHandler dataBaseQueriesHandler, ICommandHandler dataBaseCommandHandler)
        {
            _logger = logger;
            this.dataBaseQueriesHandler = dataBaseQueriesHandler;
            this.dataBaseCommandHandler = dataBaseCommandHandler;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string> { "test", "test" };
        }

        [HttpGet("usernamePasswordConfimation")]
        public Response CheckCombination([FromHeader] string username, [FromHeader] string password)
        {
            return dataBaseQueriesHandler.CheckCombination(username, password);
        }


        [HttpPost("registerUser")]
        public Response RegisterUser([FromBody] AddUserCredentialCommand credential)
        {
            
            return dataBaseCommandHandler.RegisterUser(credential);
        }

        [HttpPost("addUserDetails")]
        public Response AddUserDetails([FromHeader] string username, [FromHeader] string password, [FromBody] AddUserDetailsCommand details)
        {
            var credentials = new UserCredential(username, password);
            return dataBaseCommandHandler.AddUserDetails(details, credentials);
        }


    }
}
