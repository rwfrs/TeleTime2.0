using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeleTime.Models
{
    public class WorkDay
    {
        public int ID { get; set; }

        public int DayID { get; set; }
        public virtual Day Day { get; set; }

        public int ShiftID { get; set; }
        public virtual Shift Shifts { get; set; }
    }
}