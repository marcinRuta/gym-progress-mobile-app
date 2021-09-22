using DataBaseApi.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseApi.Application.Queries
{
    public interface IDataBaseQueriesHandler
    {
        Response CheckCombination(string username, string password);
        Response CheckUserDetails(string username, string password);
        UserDetails GetUserDetails(string username, string password);

        Response AddTrainingSession(string username, string password, TrainingSessions session);
    }
}
