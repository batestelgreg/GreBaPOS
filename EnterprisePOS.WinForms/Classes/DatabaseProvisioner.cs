using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace EnterprisePOS.WinForms
{
    /// <summary>
    /// Installs and configures the Batestel database automatically on the embedded
    /// LocalDB instance. Runs Batestel_Schema.sql when the database is missing and
    /// Batestel_Seed.sql (idempotent) afterwards, so no manual database setup is
    /// ever required by the user.
    /// </summary>
    public static class DatabaseProvisioner
    {
        private const string DatabaseName = "Batestel";

        public static void EnsureDatabaseReady(string applicationConnectionString)
        {
            string scriptsFolder =
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sql");

            SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder(applicationConnectionString);

            builder.InitialCatalog = "master";

            // First-ever connection creates and starts the LocalDB instance,
            // which can take longer than the default timeout - allow generous time.
            builder.ConnectTimeout = 60;

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                if (IsDatabaseMissing(connection))
                {
                    string schemaPath = Path.Combine(scriptsFolder, "Batestel_Schema.sql");

                    if (!File.Exists(schemaPath))
                    {
                        throw new FileNotFoundException(
                            "The database file '" + DatabaseName + "' could not be created " +
                            "because the setup script '" + schemaPath + "' is missing.",
                            schemaPath);
                    }

                    ExecuteScript(connection, schemaPath);
                }

                // The seed script is idempotent (guarded by IF NOT EXISTS checks),
                // so it is safe to run on every startup.
                string seedPath = Path.Combine(scriptsFolder, "Batestel_Seed.sql");

                if (File.Exists(seedPath))
                {
                    ExecuteScript(connection, seedPath);
                }
            }
        }

        private static bool IsDatabaseMissing(SqlConnection connection)
        {
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText =
                    "SELECT CASE WHEN DB_ID(@DatabaseName) IS NULL THEN 1 ELSE 0 END";
                command.CommandTimeout = 120;
                command.Parameters.AddWithValue("@DatabaseName", DatabaseName);

                return Convert.ToInt32(command.ExecuteScalar()) == 1;
            }
        }

        /// <summary>
        /// Executes a T-SQL script on the given connection by splitting it into
        /// batches on GO separators, which SqlClient cannot send as-is.
        /// </summary>
        private static void ExecuteScript(SqlConnection connection, string scriptPath)
        {
            string script = File.ReadAllText(scriptPath);

            foreach (string batch in SplitBatches(script))
            {
                if (string.IsNullOrWhiteSpace(batch))
                {
                    continue;
                }

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = batch;
                    command.CommandTimeout = 120;
                    command.ExecuteNonQuery();
                }
            }
        }

        private static IEnumerable<string> SplitBatches(string script)
        {
            StringBuilder current = new StringBuilder();

            foreach (string line in script.Replace("\r\n", "\n").Split('\n'))
            {
                if (line.Trim().Equals("GO", StringComparison.OrdinalIgnoreCase))
                {
                    yield return current.ToString();
                    current.Clear();
                }
                else
                {
                    current.AppendLine(line);
                }
            }

            yield return current.ToString();
        }
    }
}
