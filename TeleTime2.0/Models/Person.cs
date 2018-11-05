using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeleTime.Models
{
    // Class for the people that are hired and are connected to WorkShift.
    public class Person
    {
        // Primary key
        public int ID { get; set; }
        // Name of the person
        public string Name { get; set; }
        // TODO - add more properys after clients needs.
    
        // Connection to the WorkShift entity.
        public List<WorkShift> WorkShift { get; set; }
    }
}