using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeleTime.Models
{
    public class Time
    {
        public int ID { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public string WorkTime
        {
            get { return $"{StartTime} - {EndTime}"; }
        }

        public List<WorkShift> WorkShift { get; set; }

        // Create this one to show just one shift

        //// GET: WorkShift/ShowShift/5
        //public ActionResult ShowShift(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    List<WorkShift> workShifts = db.WorkShifts.Include(w => w.Person).Include(w => w.Shift).Where(x => x.Shift.ID == id).ToList();
        //    if (workShifts == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(workShifts);
        //}

    }
}