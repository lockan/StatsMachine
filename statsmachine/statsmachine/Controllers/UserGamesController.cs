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
    public class UserGamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserGames
        public ActionResult Index()
        {
            List<UserGamesViewModel> usergames = new List<UserGamesViewModel>();
            UserGamesViewModel ugvm; 
            foreach (UserGame u in db.UserGames.ToList())
            {
                ugvm = new UserGamesViewModel();
                ugvm.Id = u.userid;
                ugvm.gameid = (Enums.GameTitle)Enum.Parse(typeof(Enums.GameTitle), u.gameid);
                ugvm.username = db.Users.Find(u.userid).UserName;
                usergames.Add(ugvm);
            }
            
            return View(usergames);
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
        public ActionResult Create([Bind(Include = "Id,gameid")] UserGamesViewModel userGame)
        {
            if (ModelState.IsValid)
            {
                //Verify that both the user and game already exist in the database
                bool usr = db.Users.Any(u => u.Id.Equals(userGame.Id));
                bool gm = db.GameSystems.Any(g => g.id.Equals(userGame.gameid.ToString()));
                if ( !usr || !gm ) return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid userid or gameid");

                //Check for pre-existing entry
                var ug = db.UserGames.Find(userGame.Id, userGame.gameid.ToString());
                if (ug != null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "An entry matching that id combination already exists.");

                UserGame ugm = new Models.UserGame();
                ugm.userid = userGame.Id;
                ugm.gameid = userGame.gameid.ToString();
                
                db.UserGames.Add(ugm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userGame);
        }
        
        // GET: UserGames/Create
        public ActionResult Subscribe()
        {
            return View();
        }

        // POST: UserGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Subscribe([Bind(Include = "gameid")] UserGamesViewModel userGame)
        {
            if (ModelState.IsValid)
            {
                string userid = User.Identity.GetUserId();
                
                //Verify that both the user and game already exist in the database
                bool usr = db.Users.Any(u => u.Id.Equals(userid));
                bool gm = db.GameSystems.Any(g => g.id.Equals(userGame.gameid.ToString()));
                if (!usr || !gm) return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid userid or gameid");

                //Check for pre-existing entry
                var ug = db.UserGames.Find(userid, userGame.gameid.ToString());
                if (ug != null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "An entry matching that id combination already exists.");

                UserGame ugm = new Models.UserGame();
                ugm.userid = userid;
                ugm.gameid = userGame.gameid.ToString();

                db.UserGames.Add(ugm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userGame);
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
