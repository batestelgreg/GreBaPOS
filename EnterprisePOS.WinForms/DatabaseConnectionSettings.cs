using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterprisePOS.WinForms
{
    public static class DatabaseConnectionSettings
    {
        private const string ConnectionModeKey = "DatabaseConnectionMode";
        private const string ServerNameKey = "DatabaseServerName";

        public static string ConnectionMode
        {
            get
            {
                return ConfigurationManager.AppSettings[ConnectionModeKey]
                    ?? "Standalone";
            }
        }

        public static string ServerName
        {
            get
            {
                return ConfigurationManager.AppSettings[ServerNameKey]
                    ?? @".\SQLEXPRESS";
            }
        }

        public static string GetConnectionString()
        {
            string mode = ConnectionMode.Trim();

            if (!mode.Equals("Standalone", StringComparison.OrdinalIgnoreCase) &&
                !mode.Equals("LAN", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    "Invalid database connection mode. Use Standalone or LAN.");
            }

            if (string.IsNullOrWhiteSpace(ServerName))
            {
                throw new InvalidOperationException(
                    "Database server name is required.");
            }

            SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder();

            builder.DataSource = ServerName.Trim();
            builder.InitialCatalog = "Batestel";
            builder.IntegratedSecurity = true;
            builder.Encrypt = true;
            builder.TrustServerCertificate = true;

            return builder.ConnectionString;
        }
    }
}