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

        public Response CheckUserDetails(string username, string password)
        {   
            var credentialCheck= dataBaseRepository.CheckAndReturnUsernamePasswordCombination(username, password);
            var result = dataBaseRepository.CheckUserDetails(username, password);

            if (credentialCheck == 0)
            {
                return new Response("Invalid combination");
            }
            else
            {
                if (result == 0)
                {
                    return new Response("No details submitted");
                }
                else
                {
                    return new Response("Details submitted");
                }
            }
        }

        public UserDetails GetUserDetails(string username, string password)
        {
            var response = CheckUserDetails(username, password);

            if (response.ResponseDescription== "Details submitted")
            {
                return dataBaseRepository.GetUserDetails(username, password);
            }
            else
            {
                return new UserDetails("No details submitted", "No details submitted", "No details submitted", "No details submitted");
            }
        }
    }
}
