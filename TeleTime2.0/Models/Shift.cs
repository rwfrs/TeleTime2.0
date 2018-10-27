using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeleTime.Models
{
    public class Shift
    {
        public int ID { get; set; }
        public string ShiftName { get; set; }

        public List<WorkShift> WorkShifts { get; set; }

        public List<WorkDay> WorkDays { get; set; }
    }
}