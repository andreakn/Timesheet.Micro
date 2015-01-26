using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Timesheet.Micro.Data.Repos;
using Timesheet.Micro.Models.Domain.Model;
using Timesheet.Micro.Models.Services;
using WebGrease.Css.Extensions;

namespace Timesheet.Micro.Controllers
{
    public class UserController : BaseController
    {

        private IUserRepository _userRepository;
        private ICryptographer _cryptographer;

        public UserController(IUserRepository userRepository, ICryptographer cryptographer)
        {
            _userRepository = userRepository;
            _cryptographer = cryptographer;
        }

        // GET: User
        public ActionResult Index()
        {   
            var users = _userRepository.GetAll();
           
            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string username, string password, string confirmpassword)
        {
            if (password != confirmpassword){Error("Passordene er ikke like");}
            if (_userRepository.UsernameExists(username)){Error("Brukernavnet er tatt, velg et annet");}
            if (password.Length<7)Error("Skjerpings, minst 7 bokstaver i passord");
            if (ErrorMessages.Any())
                return View();

            var user = new User();
            user.Username = username;
            user.PasswordSalt = _cryptographer.CreateSalt();
            user.PasswordHash = _cryptographer.GetPasswordHash(password, user.PasswordSalt);
            _userRepository.Save(user);
            Info("Bruker opprettet");
            return RedirectToAction("Index", "Home");
        }
    }
}