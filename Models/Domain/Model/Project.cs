using System;
using System.Collections.Generic;

namespace Timesheet.Micro.Models.Domain.Model
{
    public class Project : AuditedPersistentObject
    {
        public virtual Customer Customer { get; set; }
        public virtual ProjectType ProjectType { get; set; }
        public virtual string ProjectCode { get; set; }
        public virtual string ExternalProjectCode { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string InvoiceGuidance { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsBillable { get; set; }
        public virtual bool IsAvailableToAll { get; set; }
        public virtual double? EstimateDuration { get; set; }
        public virtual DateTime? CompletionDate { get; set; }
        public virtual Employee ProjectManager { get; set; }
        public virtual IList<TimeEntry> TimeEntries { get; set; }
        public virtual IList<Invoice> Invoices { get; set; }
        public virtual IList<ProjectMember> ProjectMembers { get; set; }
        public virtual IList<StaffingEntry> StaffingEntries { get; set; }
        public virtual double? HoursStaffed { get; set; }
        public virtual double? ProjectHourlyRate { get; set; } 
    }
}
