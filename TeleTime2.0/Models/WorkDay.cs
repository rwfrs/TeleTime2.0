using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeleTime.Models
{
    // Class that combines the Day with the Shift. 
    public class WorkDay
    {
        // Primary key
        public int ID { get; set; }

        // Connection to Day
        public int DayID { get; set; }
        public virtual Day Day { get; set; }

        // Connection to Shift
        public int ShiftID { get; set; }
        public virtual Shift Shifts { get; set; }
    }
}