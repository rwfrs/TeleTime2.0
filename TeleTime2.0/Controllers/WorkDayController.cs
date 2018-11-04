using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeleTime.DAL;
using TeleTime.Models;

namespace TeleTime.Controllers
{
    public class WorkDayController : Controller
    {
        private SchedulerContext db = new SchedulerContext();

        // GET: WorkDay
        public ActionResult Index()
        {
            var workDays = db.WorkDays.Include(w => w.Day).Include(w => w.Shifts);
            return View(workDays.ToList());
        }

        // GET: WorkDay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkDay workDay = db.WorkDays.Find(id);
            if (workDay == null)
            {
                return HttpNotFound();
            }
            return View(workDay);
        }

        // GET: WorkDay/Create
        public ActionResult Create()
        {
            ViewBag.DayID = new SelectList(db.Days, "ID", "Date");
            ViewBag.ShiftID = new SelectList(db.Shifts, "ID", "ShiftName");
            return View();
        }

        // GET: WorkDay/CreateDate/
        public ActionResult CreateDate(string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);

            //Day day = db.Days.Where(x => x.Date == dateTime).First();

            //ViewBag.Day = day;

            // http://localhost:65386/WorkDay/CreateDate/?date=20181001

            ViewBag.DayID = new SelectList(db.Days.Where(x => x.Date == dateTime), "ID", "Date");

            ViewBag.ShiftID = new SelectList(db.Shifts, "ID", "ShiftName");
            return View();
        }

        // POST: WorkDay/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDate([Bind(Include = "ID,DayID,ShiftID")] WorkDay workDay)
        {
            //TODO - Do I have to include a DB-reference here? Include Day and ShiftName?

            var workDayDate = db.Days.Where(x => x.ID == workDay.DayID).First();

            var workDayShift = db.Shifts.Where(x => x.ID == workDay.ShiftID).First();

            var kalender = new SchedulerContext();

            Event newEvent = new Event();

            newEvent.start_date = workDayDate.Date;
            newEvent.end_date = workDayDate.Date.AddHours(23);
            newEvent.text = workDayShift.ShiftName;

            kalender.Events.Add(newEvent);
            kalender.SaveChanges();

            if (ModelState.IsValid)
            {
                if (workDay.Shifts == null)
                {
                    return RedirectToAction("Index", "Shift");
                }
                var redirectID = workDay.ShiftID;
                    db.WorkDays.Add(workDay);
                    db.SaveChanges();
                    return RedirectToAction("ShowShift", "WorkShift", new { id = redirectID });
                    // return RedirectToAction("Index");
            }

            ViewBag.DayID = new SelectList(db.Days, "ID", "ID", workDay.DayID);
            ViewBag.ShiftID = new SelectList(db.Shifts, "ID", "ShiftName", workDay.ShiftID);
            return View(workDay);
        }

        // POST: WorkDay/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DayID,ShiftID")] WorkDay workDay)
        {
            if (ModelState.IsValid)
            {
                if (workDay.Shifts == null)
                {
                 return RedirectToAction("Index", "Shift");
                }
                var redirectID = workDay.ShiftID;
                db.WorkDays.Add(workDay);
                db.SaveChanges();
                return RedirectToAction("ShowShift", "WorkShift", new { id = redirectID });
                    // return RedirectToAction("Index");        
            }

            ViewBag.DayID = new SelectList(db.Days, "ID", "ID", workDay.DayID);
            ViewBag.ShiftID = new SelectList(db.Shifts, "ID", "ShiftName", workDay.ShiftID);
            return View(workDay);
        }

        // GET: WorkDay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkDay workDay = db.WorkDays.Find(id);
            if (workDay == null)
            {
                return HttpNotFound();
            }
            ViewBag.DayID = new SelectList(db.Days, "ID", "ID", workDay.DayID);
            ViewBag.ShiftID = new SelectList(db.Shifts, "ID", "ShiftName", workDay.ShiftID);
            return View(workDay);
        }

        // POST: WorkDay/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DayID,ShiftID")] WorkDay workDay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workDay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DayID = new SelectList(db.Days, "ID", "ID", workDay.DayID);
            ViewBag.ShiftID = new SelectList(db.Shifts, "ID", "ShiftName", workDay.ShiftID);
            return View(workDay);
        }

        // GET: WorkDay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkDay workDay = db.WorkDays.Find(id);
            if (workDay == null)
            {
                return HttpNotFound();
            }
            return View(workDay);
        }

        // POST: WorkDay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkDay workDay = db.WorkDays.Find(id);
            db.WorkDays.Remove(workDay);
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
