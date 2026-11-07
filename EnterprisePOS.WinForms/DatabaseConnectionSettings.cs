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

        // Embedded SQL Server Express LocalDB instance. It starts on demand when
        // the application connects, so no manual database engine setup is needed.
        private const string StandaloneLocalDbSource = @"(localdb)\MSSQLLocalDB";

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

            SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder();

            if (mode.Equals("Standalone", StringComparison.OrdinalIgnoreCase))
            {
                // Embedded LocalDB instance - starts automatically on demand.
                builder.DataSource = StandaloneLocalDbSource;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(ServerName))
                {
                    throw new InvalidOperationException(
                        "Database server name is required in LAN mode.");
                }

                builder.DataSource = ServerName.Trim();
            }

            builder.InitialCatalog = "Batestel";
            builder.IntegratedSecurity = true;
            builder.TrustServerCertificate = true;

            if (mode.Equals("Standalone", StringComparison.OrdinalIgnoreCase))
            {
                // Some LocalDB instance versions do not support encryption.
                builder.Encrypt = false;
            }
            else
            {
                builder.Encrypt = true;
            }

            return builder.ConnectionString;
        }
    }
}