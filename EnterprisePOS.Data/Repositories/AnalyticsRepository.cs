using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterprisePOS.Data.Repositories
{
    public class AnalyticsRepository
    {
        public object GetDailySales(
            int actorUserId,
            DateTime from,
            DateTime to)
        {
            DatabaseRepository database = new DatabaseRepository();

            using (var context = database.CreateContext())
            {
                return context.usp_Report_DailySales(
                    actorUserId, from, to).ToList();
            }
        }

        public object GetTopProducts(
            int actorUserId,
            DateTime from,
            DateTime to)
        {
            DatabaseRepository database = new DatabaseRepository();

            using (var context = database.CreateContext())
            {
                return context.usp_Report_TopProducts(
                    actorUserId, from, to, 10).ToList();
            }
        }

        public object GetCashierSales(
            int actorUserId,
            DateTime from,
            DateTime to)
        {
            DatabaseRepository database = new DatabaseRepository();

            using (var context = database.CreateContext())
            {
                return context.usp_Report_SalesByCashier(
                    actorUserId, from, to).ToList();
            }
        }

        public object GetCategorySales(
            int actorUserId,
            DateTime from,
            DateTime to)
        {
            DatabaseRepository database = new DatabaseRepository();

            using (var context = database.CreateContext())
            {
                return context.usp_Report_SalesByCategory(
                    actorUserId, from, to).ToList();
            }
        }

        public object GetInventoryValuation(int actorUserId)
        {
            DatabaseRepository database = new DatabaseRepository();

            using (var context = database.CreateContext())
            {
                return context.usp_Report_InventoryValuation(
                    actorUserId).ToList();
            }
        }

        public object GetAnalyticsSummary(
            int actorUserId,
            DateTime from,
            DateTime to)
        {
            DatabaseRepository database = new DatabaseRepository();

            using (var context = database.CreateContext())
            {
                return context.usp_Report_AnalyticsSummary(
                    actorUserId, from, to).FirstOrDefault();
            }
        }
    }
}