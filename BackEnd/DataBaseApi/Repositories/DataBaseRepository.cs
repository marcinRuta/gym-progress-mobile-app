using System;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DataBaseApi.Domain.Daos;
using DataBaseApi.Infrastructure;
using System.Data.SqlClient;
using DataBaseApi.Application.Dtos;

namespace DataBaseApi.Domain
{
    public class DataBaseRepository : IDataBaseRepository

    {
        public DataBaseRepository()
        {
        }

        public async Task AddUserCredentials(UserCredentials userCredentials)
        {
            const string getAddedRowIdQueryQuery = @"SELECT CAST(SCOPE_IDENTITY() as int)";


            using (var dbConnection = new SqlConnection (Constants.connectionString))
            {

                dbConnection.Open();


                using (DbTransaction transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        const string insertUserCredentialsQuery = @"INSERT INTO UsersCredentials (Username, Password) VALUES (@username, @password);";

                        int UserCredentialsId = await dbConnection.QueryFirstAsync<int>(insertUserCredentialsQuery + ";" + getAddedRowIdQueryQuery, new { username = userCredentials.Username, password = userCredentials.Password }, transaction);


                        if (!(userCredentials.UserDetails == null))
                        {
                            const string insertUserQuery = @"INSERT INTO Users (Name, Surname, Email, TelephoneNumber) VALUES (@name, @surname, @email, @telephoneNumber);";
                            Users newUser = userCredentials.UserDetails;
                            int UserId = await dbConnection.QueryFirstAsync<int>(insertUserQuery + ";" + getAddedRowIdQueryQuery, new { name = newUser.Name, surname = newUser.Surname, email = newUser.Email, telephoneNumber = newUser.TelephoneNumber }, transaction);

                            const string updateUserCredentialsQuery = @"UPDATE UsersCredentials SET UserID =@userId WHERE Id=@userCredentialsId";

                            var affectedRow = dbConnection.Execute(updateUserCredentialsQuery, new { userId = UserId, userCredentialsId = UserCredentialsId }, transaction);
                        }

                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public int CheckAndReturnUsernamePasswordCombination(string username, string password)
        {
            using (var dbConnection = new SqlConnection(Constants.connectionString))
            {

                dbConnection.Open();


                using (DbTransaction transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        const string selectCredentialQuery = @"Select Id FROM UsersCredentials Where Username=@username and Password=@password";

                        var UserCredentialsId = dbConnection.Query<int>(selectCredentialQuery, new { username = username, password = password }, transaction);

                        List<int> idsAsInt = UserCredentialsId.ToList();



                        transaction.Commit();
                        return idsAsInt[0];
                    }
                    catch (Exception e)
                    {

                        return 0;
                    }
                }
            }
        }
        public async Task AddUserDetails(Users userDetails, int credentialId)
        {
            const string getAddedRowIdQueryQuery = @"SELECT CAST(SCOPE_IDENTITY() as int)";


            using (var dbConnection = new SqlConnection(Constants.connectionString))
            {
                dbConnection.Open();

                using (DbTransaction transaction = dbConnection.BeginTransaction())
                {
                    const string insertUserDetailsQuery = @"INSERT INTO Users (Name, Surname, Email, TelephoneNumber) VALUES (@name, @surname, @email, @telephoneNumber);";

                    const string updateUserCredentialsQuery = @"UPDATE UsersCredentials SET UserID =@userId WHERE Id=@userCredentialsId";


                    try
                    {
                        int UserDetailsId = await dbConnection.QueryFirstAsync<int>(insertUserDetailsQuery + ";" + getAddedRowIdQueryQuery, new { name = userDetails.Name, surname = userDetails.Surname, email = userDetails.Email, telephoneNumber = userDetails.TelephoneNumber }, transaction);

                        var affectedRow = dbConnection.Execute(updateUserCredentialsQuery, new { userId = UserDetailsId, userCredentialsId = credentialId }, transaction);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public int CheckUserDetails(string username, string password)
        {
            using (var dbConnection = new SqlConnection(Constants.connectionString))
            {

                dbConnection.Open();


                using (DbTransaction transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        const string selectCredentialQuery = @"Select UserId FROM UsersCredentials Where Username=@username and Password=@password";

                        var UserCredentialsId = dbConnection.Query<int>(selectCredentialQuery, new { username = username, password = password }, transaction);

                        List<int> idsAsInt = UserCredentialsId.ToList();

                        transaction.Commit();

                        return idsAsInt[0];
                    }
                    catch (Exception e)
                    {

                        return 0;
                    }
                }
            }
        }

        public UserDetails GetUserDetails(string username, string password)
        {

            int UserDetailsId = CheckUserDetails(username, password);
            using (var dbConnection = new SqlConnection(Constants.connectionString))
            {

                dbConnection.Open();


                using (DbTransaction transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        const string selectDetailsQuery = @"Select * FROM Users Where Id=@id";

                       var Users = dbConnection.Query<Users>(selectDetailsQuery, new { Id=UserDetailsId }, transaction);

                        var userDetails = new List<UserDetails>();
                        foreach(var user in Users)
                        {
                            userDetails.Add( new UserDetails ( user.Name ,user.Surname ,user.Email, user.TelephoneNumber ));
                        }

                        transaction.Commit();

                        return userDetails[0];
                    }
                    catch (Exception e)
                    {

                        throw new ArgumentException();
                    }
                }
            }
        }
    }
}
