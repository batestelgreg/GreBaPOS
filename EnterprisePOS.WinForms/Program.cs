using EnterprisePOS.Data.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnterprisePOS.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                string connectionString =
                    DatabaseConnectionSettings.GetConnectionString();

                RuntimeConnectionStringProvider.Set(connectionString);

                Application.Run(new LoginForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to initialize the database connection.\n\n" + ex.Message,
                    "GreBaPOS - Startup Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}