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

        public ClientApiController(ILogger<ClientApiController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string> { "test", "test" };
        }
    }
}
