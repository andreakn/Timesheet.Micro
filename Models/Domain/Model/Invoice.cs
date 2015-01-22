using System;

namespace Timesheet.Micro.Models.Domain.Model
{
    public class Invoice : AuditedPersistentObject
    {
        public virtual Customer Customer { get; set; }
        public virtual Project Project { get; set; }
        public virtual Contact Receiver { get; set; }
        public virtual Address Address { get; set; }
        public virtual DateTime FromDate { get; set; }
        public virtual DateTime ToDate { get; set; }
        public virtual DateTime? SentDate { get; set; }
        public virtual DateTime? DueDate { get; set; }
        public virtual DateTime? PaidDate { get; set; }
        public virtual double? Amount { get; set; }
        public virtual string Description { get; set; }
    }
}
