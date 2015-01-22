using System.Collections.Generic;
using Timesheet.Micro.Models.Domain.Model;

namespace Timesheet.Micro.Data.Repos
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Project> GetCurrentProjects(Employee employee);
        Employee GetByUser(User user);
    }
}