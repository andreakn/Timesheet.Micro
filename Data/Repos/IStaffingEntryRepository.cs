using System;
using System.Collections.Generic;
using Timesheet.Micro.Models.Domain.Model;

namespace Timesheet.Micro.Data.Repos
{
    public interface IStaffingEntryRepository
    {
        StaffingEntry GetEntry(Project project, Employee employee, DateTime entryDate);
        StaffingEntry GetEntry(StaffingEntry staffingEntry);
        void Save(StaffingEntry staffingEntry);
        void Delete(StaffingEntry staffingEntry);
        IEnumerable<StaffingEntry> GetEmployeeEntriesForPeriod(Employee employee, DateTime fromDate,
                                                                       DateTime toDate);
    }
}