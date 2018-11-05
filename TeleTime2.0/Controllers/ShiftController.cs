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
    public class ShiftController : Controller
    {
        private SchedulerContext db = new SchedulerContext();

        // GET: Shift
        public ActionResult Index()
        {
            return View(db.Shifts.ToList());
        }

        // GET: Shift/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shift shift = db.Shifts.Find(id);
            if (shift == null)
            {
                return HttpNotFound();
            }
            return View(shift);
        }

        // GET: Shift/DetailsAboutShift/5
        public ActionResult DetailsAboutShift(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var workDays = db.WorkDays.Include(w => w.Day).Include(w => w.Shifts).Where(x => x.ShiftID == id).ToList();
            
            if (workDays == null)
            {
                return HttpNotFound();
            }
            return View(workDays);
        }

        // GET: Shift/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shift/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ShiftName")] Shift shift)
        {
            if (ModelState.IsValid)
            {
                db.Shifts.Add(shift);
                db.SaveChanges();
                // Redirect to the WorkShift controller because it's the natural thing to do after you create a Shift.
                return RedirectToAction("Create", "WorkShift", new { id = shift.ID });
            }

            return View(shift);
        }

        // The Edit methods are excluded at the moment -> it's just a way to change the name and we can't really get it to work with our calendar.
        // GET: Shift/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shift shift = db.Shifts.Find(id);
            if (shift == null)
            {
                return HttpNotFound();
            }
            return View(shift);
        }

        // The Edit methods are excluded at the moment -> it's just a way to change the name and we can't really get it to work with our calendar.
        // POST: Shift/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ShiftName")] Shift shift)
        {
            var shiftName = shift.ShiftName;
            
            if (ModelState.IsValid)
            {
                db.Entry(shift).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shift);
        }

        // GET: Shift/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shift shift = db.Shifts.Find(id);
            if (shift == null)
            {
                return HttpNotFound();
            }
            return View(shift);
        }

        // POST: Shift/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shift shift = db.Shifts.Find(id);
            
            //Searches all events with the same name and removes them as well -> it's because we have a loose connection to between the calendar and the shifts throug WorkDays.
            List<Event> events = db.Events.Where(x => x.text == shift.ShiftName).ToList();
            events.ForEach(s => db.Events.Remove(s));

            db.Shifts.Remove(shift);
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
