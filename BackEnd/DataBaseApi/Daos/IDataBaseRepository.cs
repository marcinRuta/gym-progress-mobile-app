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
        Task AddUserDetails(User userDetails, int credentialsId);
    }
}
