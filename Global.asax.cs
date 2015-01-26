using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Timesheet.Micro.Data.Repos;
using Timesheet.Micro.Models;
using Timesheet.Micro.Models.Domain.Model;

namespace Timesheet.Micro
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        protected void Application_AcquireRequestState()
        {
            RedirectToLoginIfNecessary();
        }

        private void RedirectToLoginIfNecessary()
        {
            var authFreeZones = new[] {"/Auth", "/Content", "/Scripts", "/fonts","/bundles"};
            if (
                authFreeZones.Any(
                    z => HttpContext.Current.Request.Path.StartsWith(z, StringComparison.InvariantCultureIgnoreCase)))
            {
                return;
            }


            var username = System.Web.HttpContext.Current.User.Identity.Name;
            if (string.IsNullOrWhiteSpace(username))
            {
                Response.Redirect("~/Auth");
                return;
            }
            var currentUser = Session[Constants.SESSIONKEY_USER] as User;
            if (currentUser == null)
            {
                var repo = DependencyResolver.Current.GetService<IUserRepository>();
                if (repo.UsernameExists(username))
                {
                    currentUser = repo.GetByUserName(username);
                    if (currentUser != null)
                    {
                        Session[Constants.SESSIONKEY_USER] = currentUser;
                    }
                    else
                    {
                        Response.Redirect("~/Auth");
                    }
                }
                Response.Redirect("~/Auth");
            }
        }
    }
}
