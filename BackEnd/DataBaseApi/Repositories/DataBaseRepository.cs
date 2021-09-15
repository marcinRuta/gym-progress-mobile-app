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
                            User newUser = userCredentials.UserDetails;
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
        public async Task AddUserDetails(User userDetails, int credentialId)
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




        /*public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            using (var dbConnection = new SqlConnection(Constants.connectionString))
            {

                //otwarcie połączenia tym razem nie jest konieczne, Dapper zrobi to automatycznie w razie potrzeby
                //poprzednim razem otwarcia połączenia wymagało utworzenie transakcji
                const string selectDoctorSpecializationQuery = @"SELECT * FROM DoctorSpecialization";

                var doctorsSpecializations = (await dbConnection.QueryAsync(selectDoctorSpecializationQuery)).Select(x => new { SpecializationId = x.SpecializationId, DoctorId = x.DoctorId });

                const string selectDoctorQuery = @"SELECT * FROM Doctor";

                var doctors = await dbConnection.QueryAsync<Doctor>(selectDoctorQuery);

                const string selectSpecializationsQuery = @"SELECT * FROM Specialization";

                var specializations = await dbConnection.QueryAsync<Specialization>(selectSpecializationsQuery);

                foreach (var doctor in doctors)
                {
                    var specializationsIdForGivenDoctor = doctorsSpecializations.Where(x => x.DoctorId == doctor.Id).Select(x => x.SpecializationId);
                    var specializationsForGivenDoctor = specializations.Where(x => specializationsIdForGivenDoctor.Contains(x.Id));
                    doctor.AddSpecializations(specializationsForGivenDoctor);
                }

                return doctors;
            }
        }*/



    }
}
