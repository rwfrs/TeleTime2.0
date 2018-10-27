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
        public int ID { get; set; }
        public string Name { get; set; }

        public List<WorkShift> WorkShift { get; set; }
    }
}