using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseApi.Application.Dtos
{
    public class Response
    {
        public string ResponseDescription { get; private set; }

        public Response(string responseDescription)
        {
            ResponseDescription = responseDescription;
        }
    }
}
