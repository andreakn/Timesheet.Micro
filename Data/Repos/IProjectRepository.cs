using System.Collections.Generic;
using Timesheet.Micro.Models.Domain.Model;

namespace Timesheet.Micro.Data.Repos
{
    public interface IProjectRepository : IRepository<Project>
    {
        IEnumerable<Project> GetAllEnabled();
        IEnumerable<ProjectType> GetProjectTypes();
        IEnumerable<Project> GetCustomerProjects(Customer customer, bool getInactive);
        IEnumerable<Project> GetEmployeeStaffedProjectsForWeek(Employee employee, int year, int week, bool getInactive);
        IEnumerable<Project> GetCurrentlyActiveEmployeeProjects(Employee employee);
        IEnumerable<Project> GetEmployeeProjectsWithRegisteredHoursForWeek(Employee employee, int year, int week);
        IEnumerable<ProjectMember> GetProjectMembers(Project project);
        IEnumerable<Project> GetAllStaffableEnabled();
    }
}