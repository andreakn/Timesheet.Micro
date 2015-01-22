namespace Timesheet.Micro.Models.Domain.Model
{
    public class ProjectMember : PersistentObject
    {
        public virtual Project Project { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual double? HourlyRate { get; set; }
        public virtual bool IsActive { get; set; }
  
        public override bool Equals(object obj)
        {
            var projectMember = obj as ProjectMember;
            if (projectMember != null && Project != null && Employee != null
                && projectMember.Employee != null && projectMember.Project != null)
            {
                return Project.Id.Equals(projectMember.Project.Id) &&
                       Employee.Id.Equals(projectMember.Employee.Id);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
