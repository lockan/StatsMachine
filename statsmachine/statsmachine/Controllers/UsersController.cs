using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using statsmachine.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace statsmachine.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Users
        public ActionResult Index()
        {
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var users = db.Users.ToList();

            List<UserViewModel> userswithroles = new List<UserViewModel>();
            UserViewModel uvm;
            foreach (ApplicationUser u in users) {
                uvm = Utility.GetUserViewModel(u.Id);
                userswithroles.Add(uvm);
            }

            return View(userswithroles);
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: Users/Create
        /*
        public ActionResult Create()
        {
            return View();
        }
        */

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,firstname,lastname,avatar,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(applicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }
        */

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,firstname,lastname,avatar,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Users/Roles/5
        // Handles both add and remove roles. 
        public ActionResult Roles(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }

            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);

            List<string> roles = new List<string>();           

            foreach (var role in userManager.GetRoles(id))
            {
                roles.Add(role);
            }

            UserViewModel uvm = Utility.GetUserViewModel(applicationUser.Id);

            List<string> allroles = new List<string>();
            foreach (var r in db.Roles)
            {
                allroles.Add(r.Name);
            }
            ViewBag.RolesList = Utility.GetAvailableRoles();

            return View(uvm);
        }
        // POST: Users/Roles/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Roles(ApplicationUser applicationUser)
        {
            //This is pretty ugly. I'll need to update this any time a role is added. 
            // The Split(',')[0] is to handle checkboxes. A checked box returns "true,false" instead of just "true". 
            List<KeyValuePair<string, string>> rolesList = new List<KeyValuePair<string, string>>();
            rolesList.Add(new KeyValuePair<string, string>("Admin", Request["Admin"].Split(',')[0]));
            rolesList.Add(new KeyValuePair<string, string>("Organizer", Request["Organizer"].Split(',')[0]));

            var userstore = new UserStore<ApplicationUser>(db);
            var usermanager = new UserManager<ApplicationUser>(userstore);

            foreach (KeyValuePair<string,string> kvp in rolesList) {
                if (kvp.Value == "true")
                {
                    if (!usermanager.IsInRole(applicationUser.Id, kvp.Key))
                    {
                        usermanager.AddToRole(applicationUser.Id, kvp.Key);
                    }
                }

                if (kvp.Value == "false")
                {
                    if (usermanager.IsInRole(applicationUser.Id, kvp.Key))
                    {
                        usermanager.RemoveFromRole(applicationUser.Id, kvp.Key);
                    }                        
                }
            }
            db.SaveChanges();

            return RedirectToAction("Index", "Users");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
    }
}
