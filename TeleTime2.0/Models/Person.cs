using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeleTime.Models
{
    public class Person
    {
        //Primary key
        [Key]
        public string Name { get; set; }
        public string EMail { get; set; }

        public List<WorkShift> WorkShifts { get; set; }
    }
}