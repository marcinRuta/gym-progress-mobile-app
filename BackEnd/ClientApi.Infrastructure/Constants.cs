using System;

namespace ClientApi.Infrastructure
{
    public class Constants
    {

        public static string connectionString = Environment.GetEnvironmentVariable("databaseconnection");

    }
}
