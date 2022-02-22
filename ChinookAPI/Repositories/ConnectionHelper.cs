using System;
using Microsoft.Data.SqlClient;

namespace ChinookAPI.Repositories
{
    public class ConnectionHelper
    {
        /// <summary>
        /// Create new connection string
        /// </summary>
        /// <returns>Connection string</returns>
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = ".\\SQLEXPRESS";
            builder.InitialCatalog = "Chinook";
            builder.IntegratedSecurity = true;
            builder.TrustServerCertificate = true;

            return builder.ConnectionString;
        }
    }
}
