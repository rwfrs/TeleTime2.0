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

        // You can sort according to the persons name and search for a person
        // GET: Person
        public ActionResult Index(string sortOrder, string searchString)
        {
            // Checks if the sortOrder has been set and returns it to the View
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_asce" : "";

            var people = db.People.ToList(); ;

            // Checks if searchString has been passed
            if (!String.IsNullOrEmpty(searchString))
            {
                people = people.Where(p => p.Name.Contains(searchString)).ToList();
            }

            switch (sortOrder)
            {
                case "name_asce":
                    people = people.OrderBy(p => p.Name).ToList();
                    break;
                default:
                    // people will show up in the order they have been added
                    break;
            }

            //return View(db.People.ToList());
            return View(people);
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

        // Method that shows which workshifts a person is included in. 
        // GET: Person/ShowPersonWorkShifts/5
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
        
        // Method that shows all days which a person are going to work.
        // GET: Person/ShowPersonWorkDays/5
        public ActionResult ShowPersonWorkDays(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Combining workshift context and workday context to list which ones a person are connected to.
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

        // Method for showing the upload page for people.
        //GET: Person/Upload
        public ActionResult Upload()
        {
            return View("Upload");
        }

        // Method that reads the uploaded excel and stores it in the data base.
        // POST: Person/Upload2
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
                    var personList = new List<Person>();
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;

                        // rowIterator tells which row to start at
                        for (int rowIterator = 1; rowIterator <= noOfRow; rowIterator++)
                        {
                            var person = new Person();
                            person.Name = workSheet.Cells[rowIterator, 1].Value.ToString();
                            personList.Add(person);
                        }
                    }
                    foreach (var p in personList)
                    {
                        db.People.Add(p);
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
