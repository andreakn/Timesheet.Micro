using System.Collections.Generic;

namespace Timesheet.Micro.Models.Domain.Model
{
    public class ProjectType : PersistentObject
    {
        public virtual string Name { get; set; }
        public virtual IList<Project> Projects { get; set; }
        public virtual bool IsStaffable { get; set; }
    }
}
