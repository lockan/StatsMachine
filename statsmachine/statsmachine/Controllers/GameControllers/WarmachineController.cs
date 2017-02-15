using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using statsmachine.Models;
using Microsoft.AspNet.Identity;

namespace statsmachine.Controllers
{
    [Authorize]
    public class WarmachineController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Warmachine  -- Shows games for current user only. 
        public ActionResult Index()
        {
            UserViewModel uvm = Utility.GetUserViewModel(User.Identity.GetUserId().ToString());
            return View(uvm);
        }

        // GET: Warmachine -- Show games for all users
        public ActionResult Games(string userid = null)
        {
            List<WarmachineGame> filteredlist = new List<WarmachineGame>();
            List<WarmachineGameLimitedViewModel> wmgvList = new List<Models.WarmachineGameLimitedViewModel>();
            WarmachineGameLimitedViewModel nextViewModel = new WarmachineGameLimitedViewModel();

            if (String.IsNullOrEmpty(userid)) {
                filteredlist = db.WarmachineGames.ToList();
            } 
            else
            {
                filteredlist = db.WarmachineGames.Where(gm => gm.UserId.Equals(userid)).ToList();
            }

            foreach (WarmachineGame gm in filteredlist)
            {
                nextViewModel = getLimitedViewModel(gm);
                wmgvList.Add(nextViewModel);
            }

            return View(wmgvList);
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
            WarmachineGame wgvm = new WarmachineGame();
            wgvm.UserId = User.Identity.GetUserId().ToString();
            
            return View(wgvm);
        }

        // POST: Warmachine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UserId,faction,result,resultType,pointSize,caster,themeforce,objective,scenario,controlPoints,opponent,opponentCaster,opponentPoints")] WarmachineGame warmachine)
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
        public ActionResult Edit([Bind(Include = "id,UserId,faction,result,resultType,pointSize,caster,themeforce,objective,scenario,controlPoints,opponent,opponentCaster,opponentPoints")] WarmachineGame warmachine)
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

        private WarmachineGameLimitedViewModel getLimitedViewModel(WarmachineGame wgm)
        {
            WarmachineGameLimitedViewModel wmglvm = new WarmachineGameLimitedViewModel();
            wmglvm.gameid = wgm.id.ToString();
            wmglvm.UserId = wgm.UserId;
            wmglvm.playername = UsersController.getFullNameFromId(wgm.UserId);
            wmglvm.faction = wgm.faction;
            wmglvm.armyicon = Utility.GetImgPath(wgm.faction.ToString());
            wmglvm.opponentFaction = wgm.opponentFaction;
            wmglvm.enemyicon = Utility.GetImgPath(wgm.opponentFaction.ToString());
            wmglvm.result = wgm.result;

            //Opponent Handling - try and match up the ids to names if possible.  
            wmglvm.opponentId = UsersController.findOpponentId(wgm.opponent);
            string oppname = UsersController.getFullNameFromId(wmglvm.opponentId);
            wmglvm.opponentname = String.IsNullOrEmpty(oppname) ? wgm.opponent : oppname;
            
            return wmglvm;
        }
    }
}
