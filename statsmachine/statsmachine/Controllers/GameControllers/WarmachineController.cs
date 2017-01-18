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
    public class WarmachineController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Warmachine
        public ActionResult Index()
        {
            return View(db.WarmachineGames.ToList());
        }

        // GET: Warmachine/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarmachineGame warmachine = db.WarmachineGames.Find(id);
            if (warmachine == null)
            {
                return HttpNotFound();
            }
            return View(warmachine);
        }

        // GET: Warmachine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Warmachine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,player,faction,result,resultType,pointSize,caster,themeforce,objective,scenario,controlPoints,opponent,opponentCaster,opponentPoints")] WarmachineGame warmachine)
        {
            if (ModelState.IsValid)
            {
                warmachine.id = Guid.NewGuid();
                db.WarmachineGames.Add(warmachine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(warmachine);
        }

        // GET: Warmachine/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarmachineGame warmachine = db.WarmachineGames.Find(id);
            if (warmachine == null)
            {
                return HttpNotFound();
            }
            return View(warmachine);
        }

        // POST: Warmachine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,player,faction,result,resultType,pointSize,caster,themeforce,objective,scenario,controlPoints,opponent,opponentCaster,opponentPoints")] WarmachineGame warmachine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warmachine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(warmachine);
        }

        // GET: Warmachine/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarmachineGame warmachine = db.WarmachineGames.Find(id);
            if (warmachine == null)
            {
                return HttpNotFound();
            }
            return View(warmachine);
        }

        // POST: Warmachine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            WarmachineGame warmachine = db.WarmachineGames.Find(id);
            db.WarmachineGames.Remove(warmachine);
            db.SaveChanges();
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
