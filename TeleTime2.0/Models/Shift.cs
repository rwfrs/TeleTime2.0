using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeleTime.Models
{
    // Are made up of many workshift to create resuable shift that are connected with days in workday entity.
    public class Shift
    {
        // Primary key
        public int ID { get; set; }
        // Name of the shift
        public string ShiftName { get; set; }

        // Connection to WorkShift
        public List<WorkShift> WorkShifts { get; set; }

        // Connection to WorkDay
        public List<WorkDay> WorkDays { get; set; }
    }
}