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
using OfficeOpenXml;

namespace TeleTime.Controllers
{
    public class PersonController : Controller
    {
        private SchedulerContext db = new SchedulerContext();

        // GET: Person
        public ActionResult Index()
        {
            return View(db.People.ToList());
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Person/Details/5
        public ActionResult ShowPersonWorkShifts(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<WorkShift> workShifts = db.WorkShifts.Include(w => w.Person).Include(w => w.Role).Include(w => w.Shift).Include(w => w.Time).Where(x => x.Person.ID == id).ToList();
            if (workShifts == null)
            {
                return HttpNotFound();
            }
            return View(workShifts);
        }

        // GET: Person/Details/5
        public ActionResult ShowPersonWorkDays(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<WorkShift> workShifts = db.WorkShifts.Include(w => w.Person).Include(w => w.Role).Include(w => w.Shift).Include(w => w.Time).Where(x => x.PersonID == id).ToList();
            List<WorkDay> workDays = db.WorkDays.Include(w => w.Day).Include(w => w.Shifts).ToList();
            List<WorkDay> personWorkDays = new List<WorkDay>();
            foreach (var day in workDays)
            {
                foreach (var shift in workShifts)
                {
                    if (day.ShiftID == shift.ShiftID)
                    {
                        personWorkDays.Add(day);
                    }
                }
            }
            
            if (personWorkDays == null)
            {
                return HttpNotFound();
            }
            return View(personWorkDays);
        }

        //GET: Person/Upload
        public ActionResult Upload()
        {
            return View("Upload");
        }


        // POST: Person/Upload
        public ActionResult Upload2(FormCollection formCollection)
        {
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["UploadedFile"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                    var usersList = new List<Person>();
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;

                        for (int rowIterator = 1; rowIterator <= noOfRow; rowIterator++)
                        {
                            var user = new Person();
                            user.Name = workSheet.Cells[rowIterator, 1].Value.ToString();
                            usersList.Add(user);
                        }
                    }
                    foreach (var item in usersList)
                    {
                        db.People.Add(item);
                    }
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
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
