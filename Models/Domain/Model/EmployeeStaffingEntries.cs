using System.Collections.Generic;

namespace Timesheet.Micro.Models.Domain.Model
{
    public class EmployeeStaffingEntries
    {
        public Employee Employee { get; set; }
        public IEnumerable<StaffingEntry> StaffingEntries { get; set; }
    }
}