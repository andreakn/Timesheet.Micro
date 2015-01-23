using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Timesheet.Micro.Data.Repos;
using Timesheet.Micro.Models;
using Timesheet.Micro.Models.Services;

namespace Timesheet.Micro.Controllers
{
    public class AuthController : BaseController
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
            return RedirectToAction("Login");
        }



        public ActionResult Login(string username)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if(!string.IsNullOrWhiteSpace(password))
            if (Authenticate(username, password))
            {
                //log in user
                FormsAuthentication.SetAuthCookie(username, true);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                Error("Galt brukernavn eller passord");
            }
            return View();
        }

        private bool Authenticate(string userName, string password)
        {
            if (!_userRepository.UsernameExists(userName)) return false;
            var user = _userRepository.GetByUserName(userName);
            var passwordHash = _cryptographer.GetPasswordHash(password, user.PasswordSalt);
            return passwordHash.Equals(user.PasswordHash);
        }

        public ActionResult NoEmployee()
        {
            FormsAuthentication.SignOut();
            Error("Beklager, denne brukeren har ikke lenger tilgang");
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}