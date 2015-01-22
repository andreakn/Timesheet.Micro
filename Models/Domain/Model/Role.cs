using System;
using System.Collections.Generic;

namespace Timesheet.Micro.Models.Domain.Model
{
    [Flags]
    public enum RoleType
    {
        User = 1,
        Staffer = 2,
        KeyAccountManager = 4,
        ProjectManager = 8,
        Invoicer = 16,
        HumanResourcesManager = 32,
        ReportAnalyst = 64,
        Administrator = 128
    }

    public class Role : PersistentObject
    {
        public virtual string Name { get; set; }
        public virtual IList<Employee> Employees { get; set; }

        public virtual RoleType RoleType
        {
            get
            {
                return (RoleType)Id;
            }
        }
    }
}
