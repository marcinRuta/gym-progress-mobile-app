using DataBaseApi.Application.Dtos;
using DataBaseApi.Domain.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseApi.Application.Queries
{
    public class DataBaseQueriesHandler: IDataBaseQueriesHandler
    {
        private readonly IDataBaseRepository dataBaseRepository;

        public DataBaseQueriesHandler(IDataBaseRepository dataBaseRepository)
        {
            this.dataBaseRepository = dataBaseRepository;
        }

        public Response CheckCombination(string username, string password)
        {
            var result = dataBaseRepository.CheckAndReturnUsernamePasswordCombination(username,password);

            if (result == 0)
            {
                return new Response("Invalid combination");
            }
            else
            {
                return new Response("Valid combination");
            }
        }
    }
}
