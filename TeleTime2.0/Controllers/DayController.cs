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
    public class DayController : Controller
    {
        private SchedulerContext db = new SchedulerContext();

        // GET: Day
        public ActionResult Index()
        {
            return View(db.Days.ToList());
        }

        // GET: Day/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Day day = db.Days.Find(id);
            if (day == null)
            {
                return HttpNotFound();
            }
            return View(day);
        }

        // GET: Day/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Day/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date")] Day day)
        {
            var dates = db.Days.Select(x => x.Date);
            if (dates.Contains(day.Date))
            {
                return View(day);
            }

            if (ModelState.IsValid)
            {
                if (!db.Days.Any(x => x.Date == day.Date))
                {
                    db.Days.Add(day);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(day);
        }

        // GET: Day/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Day day = db.Days.Find(id);
            if (day == null)
            {
                return HttpNotFound();
            }
            return View(day);
        }

        // POST: Day/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date")] Day day)
        {
            if (ModelState.IsValid)
            {
                db.Entry(day).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(day);
        }

        // GET: Day/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Day day = db.Days.Find(id);
            if (day == null)
            {
                return HttpNotFound();
            }
            return View(day);
        }

        // POST: Day/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Day day = db.Days.Find(id);
            db.Days.Remove(day);
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
