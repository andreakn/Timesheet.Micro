using System.Web.Mvc;
using Timesheet.Micro.Data.Repos;

namespace Timesheet.Micro.Controllers
{
    public class HomeController : Controller
    {

        private UserRepo userRepo;

        public HomeController(UserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        public ActionResult Index()
        {
            return View("Index",(object)userRepo.GetCurrentUser());
        }
    }
}