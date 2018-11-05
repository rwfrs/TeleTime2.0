using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeleTime.Models
{
    // A Role dictates how you will be working that shift
    public class Role
    {
        // Primary key
        public int ID { get; set; }
        // Name of the role that the person will have in the workshift
        public string RoleName { get; set; }

        // Connection to WorkShift
        public List<WorkShift> WorkShifts { get; set; }
    }
}