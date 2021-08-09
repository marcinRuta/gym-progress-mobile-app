using ClientApi.Application.DataServiceClients;
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
    }
}
