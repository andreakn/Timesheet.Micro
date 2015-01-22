using System;

namespace Timesheet.Micro.Models.Domain.Model
{
    public abstract class AuditedPersistentObject : PersistentObject
    {
        public virtual DateTime ModifiedDate { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual Employee CreatedBy { get; set; }
        public virtual Employee ModifiedBy { get; set; }
    }
}