using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TeleTime.Models
{
    // The class that is used in combination with the BasicScheduler controller and view.
    public class Event
    {
        // Primary key
        [Key]
        public int id { get; set; }
        public string text { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
    }

}