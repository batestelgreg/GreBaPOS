using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterprisePOS.Data.Repositories
{
    public class RecentTransactionsRepository
    {
        public object GetRecentTransactions(int actorUserId)
        {
            DatabaseRepository database = new DatabaseRepository();

            using (var context = database.CreateContext())
            {
                return context
                    .usp_Report_RecentTransactions(actorUserId)
                    .ToList();
            }
        }
    }
}