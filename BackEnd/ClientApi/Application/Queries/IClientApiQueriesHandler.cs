using ClientApi.Application.Commands;
using ClientApi.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApi.Application.Queries
{
    public interface IClientApiQueriesHandler
    {
        Task<Response> RegisterUser(AddUserCredentialCommand credential);
        Task<Response> LoginUser(AddUserCredentialCommand credential);
    }
}
