using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolBusManagementSystemTut15Apdb.Models;

namespace SchoolBusManagementSystemTut15Apdb.Controllers
{
    public class BusDriverPerfomanceViewModelsController : Controller
    {
        private SchoolBusContext db = new SchoolBusContext();

        // GET: BusDriverPerfomanceViewModels
        public ActionResult Index()
        {
            // return View(db.driverPerfomanceViewModels.ToList());
            List<BusDriverPerfomanceViewModel> driverPerfomanceViewModels = new List<BusDriverPerfomanceViewModel>();
            var driver = (from dr in db.drivers
                          join tr in db.trips on dr.Driverid equals tr.DriverId
                          join t in db.buses on dr.AssignedBusId equals t.BusId
                          where tr.IsCompleted == true
                          select new { dr.Name, dr.LicenseType, dr.DriverScore, dr.Salary, tr.Rating }).ToList();

            foreach( var drivers in driver)
            {
                BusDriverPerfomanceViewModel bus = new BusDriverPerfomanceViewModel();
                bus.DriverName = drivers.Name;
                bus.LicenseType = drivers.LicenseType;
                bus.PointsEarned = drivers.DriverScore;
                bus.TotalEarnings = drivers.Salary;
                bus.AverateRatings = drivers.Rating;

                driverPerfomanceViewModels.Add(bus);
            }

            return View(driverPerfomanceViewModels);
        }

        // GET: BusDriverPerfomanceViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusDriverPerfomanceViewModel busDriverPerfomanceViewModel = db.driverPerfomanceViewModels.Find(id);
            if (busDriverPerfomanceViewModel == null)
            {
                return HttpNotFound();
            }
            return View(busDriverPerfomanceViewModel);
        }

        // GET: BusDriverPerfomanceViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusDriverPerfomanceViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BusDriverId,DriverName,PointsEarned,LicenseType,TotalEarnings,AverateRatings")] BusDriverPerfomanceViewModel busDriverPerfomanceViewModel)
        {
            if (ModelState.IsValid)
            {
                db.driverPerfomanceViewModels.Add(busDriverPerfomanceViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(busDriverPerfomanceViewModel);
        }

        // GET: BusDriverPerfomanceViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusDriverPerfomanceViewModel busDriverPerfomanceViewModel = db.driverPerfomanceViewModels.Find(id);
            if (busDriverPerfomanceViewModel == null)
            {
                return HttpNotFound();
            }
            return View(busDriverPerfomanceViewModel);
        }

        // POST: BusDriverPerfomanceViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BusDriverId,DriverName,PointsEarned,LicenseType,TotalEarnings,AverateRatings")] BusDriverPerfomanceViewModel busDriverPerfomanceViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(busDriverPerfomanceViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(busDriverPerfomanceViewModel);
        }

        // GET: BusDriverPerfomanceViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusDriverPerfomanceViewModel busDriverPerfomanceViewModel = db.driverPerfomanceViewModels.Find(id);
            if (busDriverPerfomanceViewModel == null)
            {
                return HttpNotFound();
            }
            return View(busDriverPerfomanceViewModel);
        }

        // POST: BusDriverPerfomanceViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusDriverPerfomanceViewModel busDriverPerfomanceViewModel = db.driverPerfomanceViewModels.Find(id);
            db.driverPerfomanceViewModels.Remove(busDriverPerfomanceViewModel);
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
