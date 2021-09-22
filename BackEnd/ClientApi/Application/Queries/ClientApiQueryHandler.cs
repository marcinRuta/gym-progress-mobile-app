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

        public Response AddUserDetails(AddUserDetailsCommand details, UserCredential credentials)
        {
            return this.dataBaseServiceClient.AddUserDetails(details, credentials).Result;
        }

        public UserDetails GetUserDetails(string username, string password)
        {
            return dataBaseServiceClient.GetUserDetails(username, password).Result;
        }

        public Response LoginUser(AddUserCredentialCommand credential)
        {
            return dataBaseServiceClient.LoginUser(credential).Result;
        }

        public Response RegisterUser(AddUserCredentialCommand credential)
        {
            return dataBaseServiceClient.RegisterUser(credential).Result;
        }

        public Response AddTrainingSession(string username, string password, TrainingSessions session)
        {
            return dataBaseServiceClient.AddTrainingSession( username,  password, session).Result;
        }
    }
}
