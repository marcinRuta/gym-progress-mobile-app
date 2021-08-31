﻿using ClientApi.Application.Commands;
using ClientApi.Application.DataServiceClients;
using ClientApi.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApi.Application.Queries
{
    public class ClientApiQueryHandler :IClientApiQueriesHandler
    {
        private readonly IDataBaseServiceClient dataBaseServiceClient;

        public ClientApiQueryHandler(IDataBaseServiceClient dataBaseServiceClient)
        {
            this.dataBaseServiceClient = dataBaseServiceClient;
        }

        Task<Response> LoginUser(AddUserCredentialCommand credential)
        {
            return dataBaseServiceClient.LoginUser(credential);
        }

        Task<Response> RegisterUser(AddUserCredentialCommand credential)
        {
            return dataBaseServiceClient.LoginUser(credential);
        }
    }
}
