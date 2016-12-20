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
    public class GameSystemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Games
        public ActionResult Index()
        {
            return View(db.GameSystems.ToList());
        }

        // GET: Games/Details/5
/*
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameSystem game = db.GameSystems.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }
*/
        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id")] GameSystem game)
        {
            if (ModelState.IsValid)
            {
                db.GameSystems.Add(game);
                db.SaveChanges();

                //TODO: Need to created a new table Games.{GameTitle}. 
                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: Games/Edit/5
/*
                public ActionResult Edit(string id)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    GameSystem game = db.GameSystems.Find(id);
                    if (game == null)
                    {
                        return HttpNotFound();
                    }
                    return View(game);
                }
*/
        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
/*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id")] GameSystem game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }
*/
        // GET: Games/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameSystem game = db.GameSystems.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GameSystem game = db.GameSystems.Find(id);
            db.GameSystems.Remove(game);
            db.SaveChanges();
            //TODO: Remove the table {game.id} on deletion of a game. 
            //NOTE: Doing so could be extrmely destructive. Would it be better to leave the stray database tables? 
            return RedirectToAction("Index");
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
