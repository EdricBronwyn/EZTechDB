using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EZTech.Models;

namespace EZTech.Controllers
{
    public class DVDPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DVDPlans
        public ActionResult Index()
        {
            return View(db.DVDPlan.ToList());
        }

        // GET: DVDPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDPlan dVDPlan = db.DVDPlan.Find(id);
            if (dVDPlan == null)
            {
                return HttpNotFound();
            }
            return View(dVDPlan);
        }

        // GET: DVDPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DVDPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DVDPlanID,PlanName,Description,Price,MaxDVDs")] DVDPlan dVDPlan)
        {
            if (ModelState.IsValid)
            {
                db.DVDPlan.Add(dVDPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dVDPlan);
        }

        // GET: DVDPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDPlan dVDPlan = db.DVDPlan.Find(id);
            if (dVDPlan == null)
            {
                return HttpNotFound();
            }
            return View(dVDPlan);
        }

        // POST: DVDPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DVDPlanID,PlanName,Description,Price,MaxDVDs")] DVDPlan dVDPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dVDPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dVDPlan);
        }

        // GET: DVDPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDPlan dVDPlan = db.DVDPlan.Find(id);
            if (dVDPlan == null)
            {
                return HttpNotFound();
            }
            return View(dVDPlan);
        }

        // POST: DVDPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DVDPlan dVDPlan = db.DVDPlan.Find(id);
            db.DVDPlan.Remove(dVDPlan);
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
