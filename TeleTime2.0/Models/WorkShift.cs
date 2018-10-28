using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeleTime.Models
{
    public class WorkShift
    {
        public int ID { get; set; }

        public int ShiftID { get; set; }
        public Shift Shift { get; set; }

        public int PersonID { get; set; }
        public Person Person { get; set; }

        public int TimeID { get; set; }
        public Time Time { get; set; }

        public int RoleID { get; set; }
        public Role Role { get; set; }
    }
}