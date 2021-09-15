using System;

namespace DataBaseApi.Infrastructure
{
    public class Constants
    {
         public static string connectionString = Environment.GetEnvironmentVariable("databaseconnection");
        // public const string connectionString = @"Data Source=DESKTOP-NLGR6P9\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;";
        // public const string connectionString = @" Server=127.0.0.1,1433;Database=Master;User Id=SA; Password=Your_password123";
    }
}
