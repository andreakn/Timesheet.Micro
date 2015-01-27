using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Timesheet.Micro.Data.Repos;
using Timesheet.Micro.Models.Domain.Model;

namespace Timesheet.Micro.Controllers
{
    public class EmployeeOverview
    {
        public Employee Employee{ get; set; }
        public Dictionary<ProjectMember,Project> ProjectMemberships { get; set; }
    }

    public class EmployeeController : BaseController
    {
        private IUserRepository _userRepo;
        private IEmployeeRepository _employeeRepo;
        private IProjectRepository _projectRepo;
        private IProjectMemberRepository _projectMemberRepo;

        public EmployeeController(IUserRepository userRepo, IEmployeeRepository employeeRepo, IProjectRepository projectRepo, IProjectMemberRepository projectMemberRepo)
        {
            _userRepo = userRepo;
            _employeeRepo = employeeRepo;
            _projectRepo = projectRepo;
            _projectMemberRepo = projectMemberRepo;
        }

        // GET: Employee
        public ActionResult Index()
        {
            var employees = _employeeRepo.GetAllActive();
            var projects = _projectRepo.GetAllActive();
            var projectMemberships = _projectMemberRepo.GetAllActive();

            var list = new List<EmployeeOverview>();

            foreach (var employee in employees)
            {
                var eo = new EmployeeOverview {Employee = employee,ProjectMemberships = new Dictionary<ProjectMember, Project>()};
                list.Add(eo);

                foreach (var memberships in projectMemberships.Where(pm=>pm.EmployeeId==employee.Id))
                {
                    var project = projects.FirstOrDefault(p => p.Id == memberships.ProjectId);
                    if (project == null) continue;//inactive
                    eo.ProjectMemberships[memberships] = project;
                }
            }

            return View(list);
        }

        public ActionResult Create()
        {
            var employee = new Employee();
            employee.IsActive = true;
            return View(employee);
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
           Info("Wohoo, lagret");
            return View(employee);
        }
    }
}