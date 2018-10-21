using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeleTime.Models
{
    public class WorkShift
    {
        [Key]
        public int WorkShiftID { get; set; } 

        public string WorkShiftNameName { get; set; }
        public WorkShiftName WorkShiftName { get; set; }

        public string Name { get; set; }
        public Person Person { get; set; }

        public string StartEndTime { get; set; }
        public Time Times { get; set; }

        public string ShiftName { get; set; }
        public TypeOfShift TypeOfShift { get; set; }

        public int? DateID { get; set; }
        public WorkDay WorkDay { get; set; }
    }
}