using EnterprisePOS.Data.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnterprisePOS.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                string connectionString =
                    DatabaseConnectionSettings.GetConnectionString();

                if (args.Any(arg =>
                    arg.Equals("/provision", StringComparison.OrdinalIgnoreCase)))
                {
                    // Silent database setup mode, used by the installer.
                    // Failures must not show a dialog because the installer runs
                    // this exe hidden - communicate via exit code + log only.
                    try
                    {
                        DatabaseProvisioner.EnsureDatabaseReady(connectionString);
                        Environment.Exit(0);
                    }
                    catch (Exception provisionEx)
                    {
                        string logPath = Path.Combine(
                            Environment.GetEnvironmentVariable("TEMP"),
                            "GreBaPOS_Provision.log");

                        File.WriteAllText(logPath, provisionEx.ToString());

                        Environment.Exit(1);
                    }
                }

                RuntimeConnectionStringProvider.Set(connectionString);
                DatabaseProvisioner.EnsureDatabaseReady(connectionString);

                Application.Run(new LoginForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to initialize the database connection.\n\n" + ex.Message,
                    "Enterprise POS - Startup Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}