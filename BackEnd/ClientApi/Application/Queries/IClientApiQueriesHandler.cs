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
        Response RegisterUser(AddUserCredentialCommand credential);
        Response LoginUser(AddUserCredentialCommand credential);
        Response AddUserDetails(AddUserDetailsCommand details, UserCredential credentials);
        UserDetails GetUserDetails(string username, string password);
        Response AddTrainingSession(string username, string password,TrainingSessions session);
    }
}
