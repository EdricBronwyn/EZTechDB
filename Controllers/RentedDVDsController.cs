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
    public class RentedDVDsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RentedDVDs
        public ActionResult Index()
        {
            var rentedDVD = db.RentedDVD.Include(r => r.Customer).Include(r => r.DVDPlan);
            return View(rentedDVD.ToList());
        }

        // GET: RentedDVDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentedDVD rentedDVD = db.RentedDVD.Find(id);
            if (rentedDVD == null)
            {
                return HttpNotFound();
            }
            return View(rentedDVD);
        }

        // GET: RentedDVDs/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "UserName");
            ViewBag.DVDPlanID = new SelectList(db.DVDPlan, "DVDPlanID", "PlanName");
            return View();
        }

        // POST: RentedDVDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentedDVDID,RentalDate,ReturnDate,CustomerID,DVDPlanID")] RentedDVD rentedDVD)
        {
            if (ModelState.IsValid)
            {
                db.RentedDVD.Add(rentedDVD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "UserName", rentedDVD.CustomerID);
            ViewBag.DVDPlanID = new SelectList(db.DVDPlan, "DVDPlanID", "PlanName", rentedDVD.DVDPlanID);
            return View(rentedDVD);
        }

        // GET: RentedDVDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentedDVD rentedDVD = db.RentedDVD.Find(id);
            if (rentedDVD == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "UserName", rentedDVD.CustomerID);
            ViewBag.DVDPlanID = new SelectList(db.DVDPlan, "DVDPlanID", "PlanName", rentedDVD.DVDPlanID);
            return View(rentedDVD);
        }

        // POST: RentedDVDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentedDVDID,RentalDate,ReturnDate,CustomerID,DVDPlanID")] RentedDVD rentedDVD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentedDVD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "UserName", rentedDVD.CustomerID);
            ViewBag.DVDPlanID = new SelectList(db.DVDPlan, "DVDPlanID", "PlanName", rentedDVD.DVDPlanID);
            return View(rentedDVD);
        }

        // GET: RentedDVDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentedDVD rentedDVD = db.RentedDVD.Find(id);
            if (rentedDVD == null)
            {
                return HttpNotFound();
            }
            return View(rentedDVD);
        }

        // POST: RentedDVDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentedDVD rentedDVD = db.RentedDVD.Find(id);
            db.RentedDVD.Remove(rentedDVD);
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
