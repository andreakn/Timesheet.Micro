using System;
using System.Collections.Generic;

namespace Timesheet.Micro.Models.Domain.Model
{
    public class Employee : AuditedPersistentObject
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Title { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual string HomePhone { get; set; }
        public virtual DateTime? BirthDate { get; set; }
        public virtual DateTime? LastLockedHours { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual IList<TimeEntry> TimeEntries { get; set; }
        public virtual IList<StaffingEntry> StaffingEntries { get; set; }
        public virtual IList<ProjectMember> MemberOfProjects { get; set; }
        public virtual IList<Project> ProjectManagerProjects { get; set; }
        public virtual User User { get; set; }
        public virtual IList<Role> Roles { get; set; }
        
        public virtual string FullName
        {
            get
            {
                if (FirstName == null && LastName == null)
                    return string.Empty;
                if (FirstName == null)
                    return LastName;
                if (LastName == null)
                    return FirstName;
                return FirstName + " " + LastName;
            }
        }
        public static Employee Dummy()
        {
             return new Employee() {FirstName = "ukjent", LastName = "ukjent", Address = "ukjent", City = "ukjent"}; 
        }
    }
}
