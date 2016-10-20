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
    public class MainController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Main
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                UserViewModel currentuser = GetCurrentUserViewModel(User.Identity.GetUserId());
                Session.Add("UserAvatar", currentuser.avatar);
                return View(currentuser);
            } else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //HELPER - Return a UserViewModel object for the current user
        private UserViewModel GetCurrentUserViewModel(string userid)
        {
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);
                        
            ApplicationUser user = db.Users.Find(userid);
            if (user == null)
            {
                return null;
            }

            UserViewModel uvm = new UserViewModel();
            uvm.Id = user.Id;
            uvm.firstname = user.firstname;
            uvm.lastname = user.lastname;
            uvm.avatar = user.avatar;
            uvm.username = user.UserName;

            uvm.roles = new List<string>();
            foreach (var role in userManager.GetRoles(user.Id))
            {
                uvm.roles.Add(role);
            }

            return uvm;
        }
    }
}