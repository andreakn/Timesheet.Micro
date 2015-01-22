using System;
using Timesheet.Micro.Models.Extensions;

namespace Timesheet.Micro.Models.Domain.Model
{
    public abstract class ProjectTime : PersistentObject
    {
        public virtual Project Project { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual double? Hours { get; set; }
        
        public override bool Equals(object obj)
        {
            var timeEntry = obj as ProjectTime;
            if (timeEntry != null && Project != null && Employee != null
                && timeEntry.Employee != null && timeEntry.Project != null)
            {
                return Project.Id.Equals(timeEntry.Project.Id) &&
                       Employee.Id.Equals(timeEntry.Employee.Id) &&
                       Date.CompareDate(timeEntry.Date);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
