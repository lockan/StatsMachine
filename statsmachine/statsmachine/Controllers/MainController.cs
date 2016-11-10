using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using statsmachine.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace statsmachine.Controllers
{
    [Authorize]
    public class MainController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Main
        public ActionResult Index()
        {
            ApplicationUser sessionuser = db.Users.Find(User.Identity.GetUserId());
            SetUserSessionData(sessionuser);
            UserViewModel currentuser = Utility.GetUserViewModel(sessionuser.Id);
            return View(currentuser);
        }

        private void SetUserSessionData(ApplicationUser sessionuser)
        {
            //Set session variables
            Session.Add("UserName", sessionuser.UserName);
            Session.Add("UserFirstName", sessionuser.firstname);
            Session.Add("UserLastName", sessionuser.lastname);
            Session.Add("UserAvatar", sessionuser.avatar);
        }

    }
}