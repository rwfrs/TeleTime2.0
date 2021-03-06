﻿using System;
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
            var workShifts = db.WorkShifts.Include(w => w.Person).Include(w => w.Role).Include(w => w.Shift).Include(w => w.Time);
            return View(workShifts.ToList());
        }

        // Method that shows a specific shift and its workshifts depending if a shiftname is passed in or shiftID.
        // GET: WorkShift/ShowShift/5 or shiftName
        public ActionResult ShowShift(int? id, string shiftName = "null")
        {
            
            if (shiftName != "null")
            {
                List<WorkShift> workShiftsName = db.WorkShifts.Include(w => w.Person).Include(w => w.Role).Include(w => w.Shift).Include(w => w.Time).Where(x => x.Shift.ShiftName == shiftName).ToList();
                ViewBag.ID = workShiftsName.Select(x => x.ShiftID).First();
                ViewBag.Name = workShiftsName.Select(x => x.Shift.ShiftName).First();
                return View(workShiftsName);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<WorkShift> workShifts = db.WorkShifts.Include(w => w.Person).Include(w => w.Role).Include(w => w.Shift).Include(w => w.Time).Where(x => x.Shift.ID == id).ToList();
            if (workShifts == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = id;
            ViewBag.Name = workShifts.Select(x => x.Shift.ShiftName).First();
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

        // GET: WorkShift/Create/5 - ShiftID
        public ActionResult Create(int? id)
        {
            ViewBag.PersonID = new SelectList(db.People, "ID", "Name");
            ViewBag.RoleID = new SelectList(db.Roles, "ID", "RoleName");
            ViewBag.ShiftID = new SelectList(db.Shifts.Where(x => x.ID == id), "ID", "ShiftName");
            ViewBag.TimeID = new SelectList(db.Times, "ID", "WorkTime");
            return View();
        }

        // POST: WorkShift/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ShiftID,PersonID,TimeID,RoleID")] WorkShift workShift)
        {
            if (ModelState.IsValid)
            {
                db.WorkShifts.Add(workShift);
                db.SaveChanges();
                // Redirects to ShowShift with the specified ID. That way you only see the shift you are creating.
                return RedirectToAction("ShowShift", "WorkShift", new { id = workShift.ShiftID });
            }

            ViewBag.PersonID = new SelectList(db.People, "ID", "Name", workShift.PersonID);
            ViewBag.RoleID = new SelectList(db.Roles, "ID", "RoleName", workShift.RoleID);
            ViewBag.ShiftID = new SelectList(db.Shifts, "ID", "ShiftName", workShift.ShiftID);
            ViewBag.TimeID = new SelectList(db.Times, "ID", "StartTime", workShift.TimeID);
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
            ViewBag.RoleID = new SelectList(db.Roles, "ID", "RoleName", workShift.RoleID);
            ViewBag.ShiftID = new SelectList(db.Shifts, "ID", "ShiftName", workShift.ShiftID);
            ViewBag.TimeID = new SelectList(db.Times, "ID", "WorkTime", workShift.TimeID);
            return View(workShift);
        }

        // POST: WorkShift/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ShiftID,PersonID,TimeID,RoleID")] WorkShift workShift)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workShift).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ShowShift", "WorkShift", new { id = workShift.ShiftID });
            }
            ViewBag.PersonID = new SelectList(db.People, "ID", "Name", workShift.PersonID);
            ViewBag.RoleID = new SelectList(db.Roles, "ID", "RoleName", workShift.RoleID);
            ViewBag.ShiftID = new SelectList(db.Shifts, "ID", "ShiftName", workShift.ShiftID);
            ViewBag.TimeID = new SelectList(db.Times, "ID", "StartTime", workShift.TimeID);
            return View(workShift);
        }

        // GET: WorkShift/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkShift workShift = db.WorkShifts.Include(w => w.Person).Include(w => w.Role).Include(w => w.Shift).Include(w => w.Time).Where(x => x.ID == id).First();
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
            // Redirects to ShowShift with the specified ID. That way you only see the shift you are creating.
            return RedirectToAction("ShowShift", "WorkShift", new { id = workShift.ShiftID });
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
