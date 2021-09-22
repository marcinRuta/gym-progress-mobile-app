using ClientApi.Application.Commands;
using ClientApi.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApi.Application.DataServiceClients
{
    public interface IDataBaseServiceClient
    {
        Task <Response> RegisterUser(AddUserCredentialCommand credential);
        Task <Response> LoginUser(AddUserCredentialCommand credential);
        Task<Response> AddUserDetails(AddUserDetailsCommand details, UserCredential credentials);

        Task<UserDetails> GetUserDetails(string username, string password);
        Task<Response> AddTrainingSession(string username, string password, TrainingSessions session);
    }
}
