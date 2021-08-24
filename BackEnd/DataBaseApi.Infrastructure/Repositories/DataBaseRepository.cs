using DataBaseApi.Domain.Daos;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataBaseApi.Infrastructure
{
    public class DataBaseRepository : IDataBaseRepository

    {
        public DataBaseRepository()
        {
        }

        public async Task AddUserAsync(User user)
        {
            const string getAddedRowIdQueryQuery = @"SELECT CAST(SCOPE_IDENTITY() as int)";


            using (var dbConnection = new SqlConnection(Constants.connectionString))
            {

                dbConnection.Open();


                using (DbTransaction transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        /*const string insertDoctorQuery = @"INSERT INTO Doctor (Surname) VALUES (@surname);";
                        
                        int doctorId = await dbConnection.QueryFirstAsync<int>(insertDoctorQuery + ";" + getAddedRowIdQueryQuery, new { surname = doctor.Surname }, transaction);

                        var specializationIds = new List<int>();

                        const string insertSpecializationQuery = @"INSERT INTO Specialization (Type, GrantedAt) VALUES (@type,ą@grantedAt);";
                        foreach (var specialization in doctor.Specializations)
                            specializationIds.Add(await dbConnection.QueryFirstAsync<int>(insertSpecializationQuery + ";" + getAddedRowIdQueryQuery, new { type = specialization.Type, grantedAt = specialization.GrantedAt }, transaction));

                        const string insertDoctorSpecializationQuery = @"INSERT INTO DoctorSpecialization (DoctorId, SpecializationId) VALUES (@doctorId,@specializationId);";
                        foreach (var specializationId in specializationIds)
                            await dbConnection.QueryAsync(insertDoctorSpecializationQuery, new { doctorId = doctorId, specializationId = specializationId }, transaction);*/

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


        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {

            
            using (var dbConnection = new SqlConnection(Constants.connectionString))
            {
                dbConnection.Open();

                const string selectSetsQuery = @"SELECT * FROM Sets";
                
                var userSets = (await dbConnection.QueryAsync(selectSetsQuery)).Select(x => new { SpecializationId = x.SpecializationId, DoctorId = x.DoctorId });
                /*
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

                return doctors;*/
            }
        }

   

    }
}
