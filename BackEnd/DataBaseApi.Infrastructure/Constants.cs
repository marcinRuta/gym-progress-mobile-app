using System;

namespace DataBaseApi.Infrastructure
{
    public class Constants
    {
        public static string connectionString = Environment.GetEnvironmentVariable("databaseconnection");
    }
}
