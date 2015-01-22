using System;
using System.Collections.Generic;
using Timesheet.Micro.Models.Domain.Model;

namespace Timesheet.Micro.Data.Repos
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        IEnumerable<Invoice> GetInvoicesForPeriod(DateTime fromDate, DateTime toDate);
        double GetCustomerBillingTotalForPeriod(Customer customer, DateTime fromDate, DateTime toDate);
        double GetProjectBillingTotalForPeriod(Project project, DateTime fromDate, DateTime toDate);
        double GetProjectBillingTotalForYearAndWeek(Project project, int year, int week);
        double GetProjectBillingTotalForYearAndMonth(Project project, int year, int month);
    }
}