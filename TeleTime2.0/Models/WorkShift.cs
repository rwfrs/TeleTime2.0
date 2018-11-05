using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeleTime.Models
{
    // Holds the information for a single workshift in a whole Shift, which is made up of many WorkShift.
    public class WorkShift
    {
        // Primary key
        public int ID { get; set; }

        // Connection to Shift
        public int ShiftID { get; set; }
        public Shift Shift { get; set; }

        // Connection to Person
        public int PersonID { get; set; }
        public Person Person { get; set; }
        
        // Connection to Time
        public int TimeID { get; set; }
        public Time Time { get; set; }

        // Connection to Role
        public int RoleID { get; set; }
        public Role Role { get; set; }
    }
}