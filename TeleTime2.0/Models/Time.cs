using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeleTime.Models
{
    public class Time
    {
        // Primary key
        public int ID { get; set; }
        // Start och the WorkShift
        public string StartTime { get; set; }
        // End of the WorkShift
        public string EndTime { get; set; }
        // Property that returns a whole WorkTime
        public string WorkTime
        {
            get { return $"{StartTime} - {EndTime}"; }
        }

        // Connection to WorkShift
        public List<WorkShift> WorkShift { get; set; }
    }
}