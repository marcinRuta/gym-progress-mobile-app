using DataBaseApi.Application.Commands;
using DataBaseApi.Application.Queries;
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

        private readonly IDataBaseQueriesHandler DataBaseQueriesHandler;
        private readonly ICommandHandler DataBaseCommandHandler;

        private readonly ILogger<DataBaseController> _logger;

        public DataBaseController(ILogger<DataBaseController> logger)
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
