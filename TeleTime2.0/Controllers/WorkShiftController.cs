using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeleTime.DAL;
using TeleTime.Models;

namespace TeleTime2._0.Controllers
{
    public class WorkShiftController : Controller
    {
        private SchedulerContext db = new SchedulerContext();

        // GET: WorkShift
        public ActionResult Index()
        {
            var workShifts = db.WorkShifts.Include(w => w.Person).Include(w => w.Times).Include(w => w.TypeOfShift).Include(w => w.WorkShiftName);
            return View(workShifts.ToList());
        }

        // GET: WorkShift/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkShift workShift = db.WorkShifts.Find(id);
            if (workShift == null)
            {
                return HttpNotFound();
            }
            return View(workShift);
        }

        // GET: WorkShift/Create
        public ActionResult Create()
        {
            ViewBag.Name = new SelectList(db.Persons, "Name", "EMail");
            ViewBag.StartEndTime = new SelectList(db.Times, "StartEndTime", "StartEndTime");
            ViewBag.ShiftName = new SelectList(db.TypeOfShifts, "ShiftName", "ShiftName");
            ViewBag.WorkShiftNameName = new SelectList(db.WorkShiftNames, "WorkShiftNameName", "WorkShiftNameName");
            return View();
        }

        // POST: WorkShift/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkShiftID,WorkShiftNameName,Name,StartEndTime,ShiftName,Date")] WorkShift workShift)
        {
            var kalender = new SchedulerContext();

            Event newEvent = new Event();

            newEvent.start_date = workShift.Date;
            newEvent.end_date = workShift.Date.AddHours(23);
            newEvent.text = workShift.ShiftName;

            kalender.Events.Add(newEvent);
            kalender.SaveChanges();

            if (ModelState.IsValid)
            {
                db.WorkShifts.Add(workShift);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Name = new SelectList(db.Persons, "Name", "EMail", workShift.Name);
            ViewBag.StartEndTime = new SelectList(db.Times, "StartEndTime", "StartEndTime", workShift.StartEndTime);
            ViewBag.ShiftName = new SelectList(db.TypeOfShifts, "ShiftName", "ShiftName", workShift.ShiftName);
            ViewBag.WorkShiftNameName = new SelectList(db.WorkShiftNames, "WorkShiftNameName", "WorkShiftNameName", workShift.WorkShiftNameName);
            return View(workShift);
        }

        // GET: WorkShift/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkShift workShift = db.WorkShifts.Find(id);
            if (workShift == null)
            {
                return HttpNotFound();
            }
            ViewBag.Name = new SelectList(db.Persons, "Name", "EMail", workShift.Name);
            ViewBag.StartEndTime = new SelectList(db.Times, "StartEndTime", "StartEndTime", workShift.StartEndTime);
            ViewBag.ShiftName = new SelectList(db.TypeOfShifts, "ShiftName", "ShiftName", workShift.ShiftName);
            ViewBag.WorkShiftNameName = new SelectList(db.WorkShiftNames, "WorkShiftNameName", "WorkShiftNameName", workShift.WorkShiftNameName);
            return View(workShift);
        }

        // POST: WorkShift/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkShiftID,WorkShiftNameName,Name,StartEndTime,ShiftName,Date")] WorkShift workShift)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workShift).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Name = new SelectList(db.Persons, "Name", "EMail", workShift.Name);
            ViewBag.StartEndTime = new SelectList(db.Times, "StartEndTime", "StartEndTime", workShift.StartEndTime);
            ViewBag.ShiftName = new SelectList(db.TypeOfShifts, "ShiftName", "ShiftName", workShift.ShiftName);
            ViewBag.WorkShiftNameName = new SelectList(db.WorkShiftNames, "WorkShiftNameName", "WorkShiftNameName", workShift.WorkShiftNameName);
            return View(workShift);
        }

        // GET: WorkShift/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkShift workShift = db.WorkShifts.Find(id);
            if (workShift == null)
            {
                return HttpNotFound();
            }
            return View(workShift);
        }

        // POST: WorkShift/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkShift workShift = db.WorkShifts.Find(id);
            db.WorkShifts.Remove(workShift);
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
