using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using statsmachine.Models;

namespace statsmachine.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserGamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserGames
        public ActionResult Index()
        {
            return View(db.UserGames.ToList());
        }

        // GET: UserGames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userid,gameid")] UserGame userGame)
        {
            if (ModelState.IsValid)
            {
                //Verify that both the user and game already exist in the database
                bool usr = db.Users.Any(u => u.UserName.Equals(userGame.userid));
                bool gm = db.GameSystems.Any(g => g.id.Equals(userGame.gameid));
                if ( !usr || !gm ) return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid userid or gameid");

                //Check for pre-existing entry
                var ug = db.UserGames.Find(userGame.userid, userGame.gameid);
                if (ug != null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "An entry matching that id combination already exists.");

                db.UserGames.Add(userGame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userGame);
        }

        //TODO: Role this into an overloaded POST controller
        private UserGame CreateUserGameLink(string userid, string gameid)
        {
            string userMail = db.Users.Find(userid).Email;
            UserGame ug = new Models.UserGame();
            ug.userid = userMail;
            ug.gameid = gameid;

            return ug;
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
