using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterprisePOS.Data.Repositories
{
    public class DashboardRepository
    {
        public usp_Report_DashboardResult GetDashboardSummary(
            int actorUserId)
        {
            DatabaseRepository database = new DatabaseRepository();

            using (var context = database.CreateContext())
            {
                return context.usp_Report_Dashboard(actorUserId)
                              .FirstOrDefault();
            }
        }
    }
}