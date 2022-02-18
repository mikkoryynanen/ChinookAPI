using System;
using Microsoft.Data.SqlClient;

namespace ChinookAPI.Repositories
{
    public class ConnectionHelper
    {
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = ".\\SQLEXPRESS";
            builder.InitialCatalog = "Chinook";
            builder.IntegratedSecurity = true;
            builder.TrustServerCertificate = true;
            // Uncomment if IntegratedSecurity is false
            //builder.UserID = "sa";
            //builder.Password = "";
            return builder.ConnectionString;
        }
    }
}
