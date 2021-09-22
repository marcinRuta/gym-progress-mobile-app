using DataBaseApi.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi.Domain.Daos
{
    public interface IDataBaseRepository
    {
        Task AddUserCredentials(UserCredentials userCredentials);
        int CheckAndReturnUsernamePasswordCombination(string username, string password);
        Task AddUserDetails(Users userDetails, int credentialsId);
        int CheckUserDetails(string username, string password);
        UserDetails GetUserDetails(string username, string password);

        int AddTrainingSession(int id, TrainingSessions session);
    }
}
