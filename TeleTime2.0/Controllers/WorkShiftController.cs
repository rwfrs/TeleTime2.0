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

namespace TeleTime.Controllers
{
    public class WorkShiftController : Controller
    {
        private SchedulerContext db = new SchedulerContext();

        // GET: WorkShift
        public ActionResult Index()
        {
            var workShifts = db.WorkShifts.Include(w => w.Person).Include(w => w.Shift);
            return View(workShifts.ToList());
        }


        // Create this one to show just one shift

        // GET: WorkShift/ShowShift/5
        public ActionResult ShowShift(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<WorkShift> workShifts = db.WorkShifts.Include(w => w.Person).Include(w => w.Shift).Where(x => x.Shift.ID == id).ToList();
            if (workShifts == null)
            {
                return HttpNotFound();
            }
            return View(workShifts);
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
            ViewBag.PersonID = new SelectList(db.People, "ID", "Name");
            ViewBag.ShiftID = new SelectList(db.Shifts, "ID", "ShiftName");
            return View();
        }

        // POST: WorkShift/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ShiftID,PersonID")] WorkShift workShift)
        {
            if (ModelState.IsValid)
            {
                db.WorkShifts.Add(workShift);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(db.People, "ID", "Name", workShift.PersonID);
            ViewBag.ShiftID = new SelectList(db.Shifts, "ID", "ShiftName", workShift.ShiftID);
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
            ViewBag.PersonID = new SelectList(db.People, "ID", "Name", workShift.PersonID);
            ViewBag.ShiftID = new SelectList(db.Shifts, "ID", "ShiftName", workShift.ShiftID);
            return View(workShift);
        }

        // POST: WorkShift/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ShiftID,PersonID")] WorkShift workShift)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workShift).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonID = new SelectList(db.People, "ID", "Name", workShift.PersonID);
            ViewBag.ShiftID = new SelectList(db.Shifts, "ID", "ShiftName", workShift.ShiftID);
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
