using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Timesheet.Micro.Data.Repos;
using Timesheet.Micro.Models.Services;

namespace Timesheet.Micro.Controllers
{
    public class AuthController : Controller
    {
        private ICryptographer _cryptographer;
        private IUserRepository _userRepository;

        public AuthController(Cryptographer crypto, IUserRepository userRepository)
        {
            _cryptographer = crypto;
            _userRepository = userRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string username, string password)
        {
            if (Authenticate(username, password))
            {
                //log in user
                Session["user"] = username;
                //Session.Add(SessionKeys.SessionUserInfo, _userSession.GetUserInfo(user));
                //return RedirectToAction(ViewNames.Default, typeof(RegisterHoursController).GetControllerName());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Session["user"] = "could not login " + username;
            }
            return View();
        }

        private bool Authenticate(string userName, string password)
        {
            var user = _userRepository.GetByUserName(userName);
            var passwordHash = _cryptographer.GetPasswordHash(password, user.PasswordSalt);
            return passwordHash.Equals(user.PasswordHash);
        }
    }
}